using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, MyProjectContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (MyProjectContext context = new MyProjectContext())
            {
                var result = from b in context.Brands
                             join c in context.Cars
                             on b.BrandId equals c.BrandId
                             join cl in context.Colors
                             on c.ColorId equals cl.ColorId
                             select new CarDetailDto
                             {
                                 CarId=c.CarId,BrandName=b.BrandName,ColorName=cl.ColorName,ModelYear=c.ModelYear,dailyPrice=c.DailyPrice
                             };
                return result.ToList(); 
            }
        }
    }
}
