using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService
    {

        IResult Add(IFormFile file, CarImage entity);
        IResult Delete(CarImage entity);
        IResult Update(IFormFile file, CarImage entity);
        IDataResult<List<CarImage>> GetAll();
        IDataResult<List<CarImage>> GetByCarId(int id);
        IDataResult<CarImage> GetById(int id);

    }
}
