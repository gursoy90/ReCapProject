﻿using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, MyProjectContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (MyProjectContext context =new MyProjectContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars
                             on r.CarId equals c.CarId                             
                             join b in context.Brands
                             on c.CarId equals b.BrandId
                             
                             select new RentalDetailDto 
                             {
                                 RentalId=r.RentalId,
                                 CarName=b.BrandName,
                                 CarDescription=c.Description,                                 
                                 RentDate=r.RentDate,
                                 ReturnDate=r.ReturnDate,  
                                 
                             
                             };

                    return result.ToList();
            }
        }
    }
}
