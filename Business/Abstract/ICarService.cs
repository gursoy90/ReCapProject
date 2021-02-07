﻿using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
     public interface ICarService
    {
        List<Car> GetCarsByColorId(int id);
        List<Car> GetAll();
        Car GetById(int id);
        void Add(Car entity);
        void Update(Car entity);
        void Delete(Car entity);
        List<Car> GetCarsByBrandId(int id);
        List<CarDetailDto> GetCarDetails();
    }

}
