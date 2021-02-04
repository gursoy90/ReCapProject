using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    //Generic Constraint where<T>
    //class: referans tip
    //IEntity olabilir veya onu implemente eden bir nesne olabilir.
    //new(): new'lenebilir olmalı.
    public interface IDataAccessRepository<T> where T:class,new()
    {
        
        List<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
