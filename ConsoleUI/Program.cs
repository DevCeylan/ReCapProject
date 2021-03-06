﻿using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager( new EfCarDal() );

            Console.WriteLine("-- GetAll Function Call: \n");
            foreach (var c in carManager.GetAll())
            {
                Console.WriteLine(c.CarId + " " + c.Description);
            }

            Console.WriteLine("\n-- GetById Function Call: \n");
            Car car = carManager.GetCarById(2);
            Console.WriteLine("Car id= " + car.CarId + ": " + car.Description );

            Console.WriteLine("\n-- Add Function Call: \n");
            Car carToAdd = new Car { CarId = 7, BrandId = 3, ColorId = 2, ModelYear = 2020, DailyPrice = 300, Description = "Peugeot 308" };
            carManager.Add(carToAdd);
            foreach (var c in carManager.GetAll()) // to see the changes
            {
                Console.WriteLine(c.CarId + " " + c.Description);
            }

            Console.WriteLine("\n-- Update Function Call: \n");
            carManager.Update(new Car { CarId = 7, BrandId = 3, ColorId = 1, ModelYear = 2018, DailyPrice = 250, Description = "Peugeot 308 - Updated" });
            foreach (var c in carManager.GetAll()) // to see the changes
            {
                Console.WriteLine(c.CarId + " " + c.Description);
            }

        }
    }
}
