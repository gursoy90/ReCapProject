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
           // CarCrud();

            Console.WriteLine("---------------------------------------");

           // ColorCrud();

            Console.WriteLine("---------------------------------------");
           // BrandCrud();

            Console.WriteLine("---------------------------------------");

            Rental rent1 = new Rental() { CarId = 1, CustomerId = 1, RentDate = DateTime.Now.Date.ToString("dd-MM-yyyy") };
            RentalManager rentacar = new RentalManager(new EfRentalDal());

            //rentacar.Add(rent1);

            if (rentacar.GetAll().Success)
            {
                foreach (var rental in rentacar.GetAll().Data)
                {
                    Console.WriteLine(rental.RentalId + " " + rental.RentDate);
                }
            }
            else
            {
                Console.WriteLine(rentacar.GetAll().Message);
            }
            
            Console.WriteLine("---------------------------------------");
            
            
           

        }

        private static void BrandCrud()
        {
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
        }

        private static void ColorCrud()
        {
            ColorManager colorManager = new ColorManager(new EFColorDal());

            Color newColor = new Color() { ColorName = "Lacivert" };

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
        }

        private static void CarCrud()
        {
            CarManager carManager = new CarManager(new EFCarDal());


            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.CarId + " " + car.BrandId + " " + car.ColorId + " " + car.ModelYear);
            }

            Car car1 = new Car() { ColorId = 3, BrandId = 2, DailyPrice = 190, ModelYear = "2019", Description = "Hatasız Lüks Otomobil" };

            carManager.Add(car1);
            car1.ModelYear = "2020";
            carManager.Update(car1);

            Console.WriteLine(carManager.GetById(1).Data.Description);


            carManager.Delete(car1);

            foreach (var car in carManager.GetCarsByBrandId(2).Data)
            {
                Console.WriteLine(car.Description);
            }
            foreach (var car in carManager.GetCarsByColorId(3).Data)
            {
                Console.WriteLine(car.Description);
            }

            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.CarId + " " + car.BrandId + " " + car.ColorId + " " + car.ModelYear);
            }
            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine("{0}-{1}-{2}-{3}-{4}", car.CarId, car.BrandName, car.ColorName, car.ModelYear, car.dailyPrice);
            }

        }
    }
}
