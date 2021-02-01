using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());


            carManager.GetAll();

            Console.WriteLine("-----------------------------");
            Car car1 = new Car { CarId = 6, BrandId = 6, ColorId = 6, DailyPrice = 625, Description = " Yeni Gelen Dizel lüks Araç", ModelYear = "2020" };
            carManager.Add(car1);

            Console.WriteLine(carManager.GetById(6).CarId + " " + carManager.GetById(6).Description);
            Console.WriteLine("-----------------------------");

            car1.Description = "Yeni Gelen Dizel lüks Araç Güncellendi.";
            carManager.Update(car1);
            Console.WriteLine(carManager.GetById(6).CarId + " " + carManager.GetById(6).Description);


            Console.WriteLine("-----------------------------");

            carManager.Delete(car1);

        }
    }
}
