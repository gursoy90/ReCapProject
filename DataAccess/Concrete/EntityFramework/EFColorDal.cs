using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFColorDal : IColorDal
    {
        
        
        public void Add(Color entity)
        {
            using (MyProjectContext _context =new MyProjectContext())
            {
                var colorAdded = _context.Entry(entity);
                colorAdded.State = EntityState.Added;
                _context.SaveChanges();
            }
        }

        public void Delete(Color entity)
        {
            using (MyProjectContext _context = new MyProjectContext())
            {
                var colorDeleted = _context.Entry(entity);
                colorDeleted.State = EntityState.Deleted;
                _context.SaveChanges();
            }
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            using (MyProjectContext _context = new MyProjectContext())
            {
                
                return filter == null ? _context.Set<Color>().ToList() : _context.Set<Color>().Where(filter).ToList();
            }

        }

        public Color GetCarsByBrandId(Expression<Func<Color, bool>> filter)
        {
            using (MyProjectContext _context = new MyProjectContext())
            {
                return _context.Set<Color>().SingleOrDefault(filter);
            }
        }

        public Color GetCarsByColorId(Expression<Func<Color, bool>> filter)
        {
            using (MyProjectContext _context = new MyProjectContext())
            {
                return _context.Set<Color>().SingleOrDefault(filter);
            }
        }

        public void Update(Color entity)
        {
            using (MyProjectContext _context = new MyProjectContext())
            {
                var carUpdated = _context.Entry(entity);
                carUpdated.State = EntityState.Modified;
                _context.SaveChanges();
            }
        }
    }
}
