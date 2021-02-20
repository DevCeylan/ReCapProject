using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> { 
            new Car { CarId = 1, BrandId = 1, ColorId = 1, ModelYear = 2017, DailyPrice = 400, Description = "Opel Insignia" },
            new Car { CarId=2, BrandId=2, ColorId=2, ModelYear=2015, DailyPrice=100, Description= "Fiat Egea" },
            new Car { CarId=3, BrandId=3, ColorId=3, ModelYear=2020, DailyPrice=120, Description= "Peugeot 208" },
            new Car { CarId=4, BrandId=3, ColorId=1, ModelYear=2018, DailyPrice=350, Description= "Peugeot 508" },
            new Car { CarId=5, BrandId=4, ColorId=1, ModelYear=2021, DailyPrice=400, Description= "Audi A3" },
            new Car { CarId=6, BrandId=4, ColorId=1, ModelYear=2018, DailyPrice=1000, Description= "Audi A7" }
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(int id)
        {
            Car carToDelete = null;

            carToDelete = _cars.SingleOrDefault(c => c.CarId == id);

            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetByBrand(int brandId)
        {
            return _cars.Where(c => c.BrandId == brandId).ToList();
        }

        public Car GetById(int id)
        {
            //Car carToSelect = null;
            //carToSelect = _cars.SingleOrDefault(c => c.CarId == id);
            //return carToSelect ;
            return _cars.SingleOrDefault(c => c.CarId == id);
        }

        public void Update(Car car)
        {
            Car carToUpdate = null;
            carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);

            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
