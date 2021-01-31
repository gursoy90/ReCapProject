﻿using Business.Abstract;
using DataAccess.Abstract;
using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _inMemoryCarDal;

        public CarManager(ICarDal inMemoryCarDal)
        {
            _inMemoryCarDal = inMemoryCarDal;
        }

        public void Add(Car car)
        {
            _inMemoryCarDal.Add(car);
        }

        public void Delete(Car car)
        {
           _inMemoryCarDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _inMemoryCarDal.GetAll();
        }

        public Car GetById(int id)
        {
             return _inMemoryCarDal.GetById(id);
        }

        public void Update(Car car)
        {
            _inMemoryCarDal.Update(car);
        }
    }
}