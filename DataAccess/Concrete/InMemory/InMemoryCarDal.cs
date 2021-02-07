using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal

    {
        List<Car> _car;
        List<Brand> _brand;
        List<Color> _color;
        

        public InMemoryCarDal()
        {
            _car = new List<Car>
            {
                new Car {CarId=1,BrandId=1,ColorId=1,DailyPrice=350,Description="Benzinli Orta Segment Araç",ModelYear="2019"},
                new Car {CarId=2,BrandId=2,ColorId=2,DailyPrice=550,Description="Dizel Araç",ModelYear="2020"},
                new Car {CarId=3,BrandId=3,ColorId=3,DailyPrice=750,Description="Dizel Lüks Araç",ModelYear="2021"},
                new Car {CarId=4,BrandId=4,ColorId=4,DailyPrice=250,Description="Benzinli Araç",ModelYear="2018"},
                new Car {CarId=5,BrandId=5,ColorId=5,DailyPrice=450,Description="Benzinli Lüks Araç",ModelYear="2021"}
            };

            _brand = new List<Brand>
            {
                new Brand {BrandId=1,BrandName="Opel Insignia"},
                new Brand {BrandId=2,BrandName="Volkswagen Passat"},
                new Brand {BrandId=3,BrandName="Mercedes E-200"},
                new Brand {BrandId=4,BrandName="Opel Astra"},
                new Brand {BrandId=5,BrandName="BMW 320i"}
            };
            

            _color = new List<Color>
            {
                new Color{ColorId=1,ColorName="Gray"},
                new Color{ColorId=2,ColorName="White"},
                new Color{ColorId=3,ColorName="Red"},
                new Color{ColorId=4,ColorName="Burgundy"},
                new Color{ColorId=5,ColorName="Black"},
            };
        }
        public void Add(Car car)
        {
            _car.Add(car);
        }

        public void Delete(Car car)
        {
            Car toDelete =null;

             toDelete = _car.SingleOrDefault(c => c.CarId == car.CarId);
             _car.Remove(toDelete);

            Console.WriteLine("Id si "+toDelete.CarId + " olan Araç Silindi");
          
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car GetById(int id)
        {
            // return _car.Where(c=> c.CarId==id ).ToList();
            //return _car.Any(c => c.CarId == id);
            return _car.Find(c => c.CarId == id);
           
        }

        public Car GetById(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public Car GetCarsByBrandId(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Car GetCarsByColorId(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car toUpdate = _car.SingleOrDefault(c => c.CarId == car.CarId);
            toUpdate.BrandId = car.BrandId;
            toUpdate.ColorId = car.ColorId;
            toUpdate.DailyPrice = car.DailyPrice;
            toUpdate.Description = car.Description;
            toUpdate.ModelYear = car.ModelYear;
        }

        
    }
}
