using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    //Generic Constraint where<T>
    //class: referans tip
    //IEntity olabilir veya onu implemente eden bir nesne olabilir.
    //new(): new'lenebilir olmalı.
    public interface IEntityRepository<T>where T:class,IEntity,new()
    {
       
        List<T> GetAll(Expression <Func<T,bool>> filter=null );
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
