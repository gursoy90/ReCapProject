using System;
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
                var result = from c in context.Cars
                             join r in context.Rentals
                             on c.CarId equals r.CarId
                             join cus in context.Customers
                             on r.CustomerId equals cus.CustomerId
                             join b in context.Brands
                             on c.CarId equals b.BrandId
                             select new RentalDetailDto 
                             {
                                 RentalId=r.RentalId,
                                 CarName=b.BrandName,
                                 CarDescription=c.Description,
                                 CustomerName=cus.CustomerName,
                                 RentDate=r.RentDate,
                                 ReturnDate=r.ReturnDate,
                                 TotalPrice=Convert.ToDouble(r.ReturnDate) - Convert.ToDouble(r.RentDate) *c.DailyPrice                            
                             
                             };

                    return result.ToList();
            }
        }
    }
}
