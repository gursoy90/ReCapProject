using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _imageDal;

        public CarImageManager(ICarImageDal imageDal)
        {
            _imageDal = imageDal;
        }
       // [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile file, CarImage entity)
        {
            var path = Environment.CurrentDirectory + @"\Images\" + entity.CarId + entity.Id + Path.GetExtension(file.FileName);
            var result = BusinessRules.Run(CheckIfCarImageLimitExceded(entity.CarId));
            if (result != null)
            {
                return result;
            }
            using (FileStream fs = File.Create(path))
            {
                file.CopyTo(fs);
                fs.Flush();
                entity.ImagePath = path;
            entity.Date = DateTime.Now;
            }

            

            _imageDal.Add(entity);
            return new SuccessResult(Messages.CarImageAdded);
        }
        
        public IResult Delete(CarImage entity)
        {
            var image = GetById(entity.Id);
            File.Delete(image.Data.ImagePath);
            _imageDal.Delete(entity);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_imageDal.GetAll(),Messages.CarImageListed);
        }

        public IDataResult<List<CarImage>> GetByCarId(int id)
        {
           var result= CheckIfCarImageNull(id);
            
            if (result!=null)
            {
                return result;
            }
            return new SuccessDataResult<List<CarImage>>(_imageDal.GetAll(c=>c.CarId==id),Messages.CarImageListed);
        }

        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_imageDal.GetById(c => c.Id == id),Messages.CarImageListed);
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(IFormFile file, CarImage entity)
        {
            var path = Environment.CurrentDirectory + @"\Images\" + entity.CarId + entity.Id + Path.GetExtension(file.FileName);
           
            using (FileStream fs = File.Create(path))
            {
                file.CopyTo(fs);
                fs.Flush();                
            }

            
            File.Delete(entity.ImagePath);
            entity.ImagePath = path;
            entity.Date = DateTime.Now;
            _imageDal.Update(entity);
            return new SuccessResult(Messages.CarImageUpdated);
        }
        private IResult CheckIfCarImageLimitExceded(int carId)
        {
            var result = _imageDal.GetAll(c => c.CarId == carId).Count;

            if (result >= 5)
            {
                return new ErrorResult(Messages.CarImagesLimitExceded);
            }
            return new SuccessResult();
        }
        private IDataResult<List<CarImage>> CheckIfCarImageNull(int id)
        {
            string path =Environment.CurrentDirectory + @"\Images\logo.jpg";
            var result = _imageDal.GetAll(c => c.CarId == id).Any();
            if (result==false)
            {
                List<CarImage> liste =new  List<CarImage>();
                liste.Add(new CarImage { CarId = id, Date = DateTime.Now, ImagePath = path });
                return new ErrorDataResult<List<CarImage>>(liste,Messages.CarImageListed);
                
            }
            return null;
        }

    }
}
