using Business.Concrete;
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
            CarManager carManager = new CarManager(new EFCarDal());

            
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.CarId +" " + car.BrandId+" " +car.ColorId+" " +car.ModelYear);
            }

            Car car1 = new Car() {ColorId = 3, BrandId = 2, DailyPrice = 190, ModelYear = "2019", Description = "Hatasız Lüks Otomobil" };

            carManager.Add(car1);
            car1.ModelYear = "2020";
            carManager.Update(car1);

            Console.WriteLine(carManager.GetById(1).Description);
            
            
            carManager.Delete(car1);

            foreach (var car in carManager.GetCarsByBrandId(2))
            {
                Console.WriteLine(car.Description);
            }
            foreach (var car in carManager.GetCarsByColorId(3))
            {
                Console.WriteLine(car.Description);
            }

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.CarId + " " + car.BrandId + " " + car.ColorId + " " + car.ModelYear);
            }

            Console.WriteLine("---------------------------------------");

            ColorManager colorManager = new ColorManager(new EFColorDal());

            Color newColor = new Color() {ColorName="Lacivert"};

            colorManager.Add(newColor);

            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorId + " " + color.ColorName);
            }
            newColor.ColorName = "Mor";
            colorManager.Update(newColor);
            Console.WriteLine(colorManager.GetById(1).ColorName);
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorId + " " + color.ColorName);
            }
            colorManager.Delete(newColor);

            
            Console.WriteLine("---------------------------------------");

            BrandManager brandManager = new BrandManager(new EFBrandDal());

            Brand newBrand = new Brand() { BrandName = "BMx" };

            brandManager.Add(newBrand);

            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandId + " " + brand.BrandName);
            }
            newBrand.BrandName = "BMC";
            brandManager.Update(newBrand);
            Console.WriteLine(brandManager.GetById(1).BrandName); 
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandId + " " + brand.BrandName);
            }
            brandManager.Delete(newBrand);

            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine("{0}-{1}-{2}-{3}-{4}",car.CarId,car.BrandName,car.ColorName,car.ModelYear,car.dailyPrice);
            }
            

        }
    }
}
