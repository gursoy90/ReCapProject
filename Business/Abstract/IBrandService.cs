using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBrandService:IDataAccessRepository<Brand>
    {
        List<Brand> GetCarsByBrandId(int id);
    }
}
