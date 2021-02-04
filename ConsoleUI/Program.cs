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

            Car car1 = new Car() {ColorId = 3, BrandId = 2, DailyPrice = 0, ModelYear = "2019", Description = "Hatasız Lüks Otomobil" };

            carManager.Add(car1);

            ColorManager colorManager = new ColorManager(new EFColorDal());

            Color newColor = new Color() {ColorName="Sarı" };

            colorManager.Add(newColor);

            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorId + " " + color.ColorName);
            }

            BrandManager brandManager = new BrandManager(new EFBrandDal());

            Brand newBrand = new Brand() { BrandName = "A" };

            brandManager.Add(newBrand);

            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandId + " " + brand.BrandName);
            }


        }
    }
}
