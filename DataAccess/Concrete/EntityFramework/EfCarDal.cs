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
    public class EfCarDal : ICarDal
    {
        public void Add(Car entity)
        {
            using (CarRentalDBContext context = new CarRentalDBContext())
            {
                var addedCar = context.Entry(entity);
                addedCar.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Car entity)
        {
            using (CarRentalDBContext context = new CarRentalDBContext())
            {
                var deletedCar = context.Entry(entity);
                deletedCar.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter = null)
        {
            using (CarRentalDBContext context = new CarRentalDBContext())
            {
                return context.Set<Car>().SingleOrDefault(filter);
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (CarRentalDBContext context = new CarRentalDBContext())
            {
                return filter == null ? context.Set<Car>().ToList() : context.Set<Car>().Where(filter).ToList();
                // filter = holding lambda expressions while using Linq queries
            }
        }

        public void Update(Car entity)
        {
            using (CarRentalDBContext context = new CarRentalDBContext())
            {
                var updatedCar = context.Entry(entity);
                updatedCar.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
