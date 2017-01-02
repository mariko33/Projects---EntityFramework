using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CarDealer.Data;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer.Client
{
    class Program
    {
        static void Main()
        {
            //System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            //customCulture.NumberFormat.NumberDecimalSeparator = ".";

           // System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;

            CarDealerContext context=new CarDealerContext();
            //context.Database.Initialize(true);

            // SeedData(context);

            //Task 1
            //OrderedCustomers(context);
           
            //Task 2
           // CarsFromMakeToyota(context);

            //Task 3
            //LocalSuppliers(context);

            //Task 4
            //CarsWithParts(context);

            //Task 5
           // TotalSalesByCustomer(context);

            //Task 6
            SalesWithAppliedDiscount(context);
        }


        private static void SalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Select(s => new
                {
                    car=new {
                        s.Car.Make,
                        s.Car.Model,
                        s.Car.TravelledDistance
                    } ,
                    s.Customer.Name,
                    Discount= s.Discount,
                    price =s.Car.Parts.Sum(p => p.Price),
                    priceWithDiscount= s.Car.Parts.Sum(p => p.Price)-s.Car.Parts.Sum(p => p.Price)*s.Discount

                });

            string json = JsonConvert.SerializeObject(sales, Formatting.Indented);
            File.WriteAllText("../../../dataexit/salesWithDiscount.json",json);
            Console.WriteLine(json);
        }
        private static void TotalSalesByCustomer(CarDealerContext context)
        {
            var customersSales = context.Customers
                .Where(c => c.Sales.Any())
                .Select(c => new
                {
                    fullName = c.Name,
                    boughtCars = c.Sales.Count,
                    spentMoney = c.Sales.Sum(s => s.Car.Parts.Sum(p => p.Price))

                })
                .OrderByDescending(c => c.spentMoney)
                .ThenByDescending(c => c.boughtCars);
            string json = JsonConvert.SerializeObject(customersSales, Formatting.Indented);
            File.WriteAllText("../../../dataexit/customersSales.json",json);
            Console.WriteLine(json);
        }
        private static void CarsWithParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(c => new
                {
                    c.Make,
                    c.Model,
                    c.TravelledDistance,
                    parts = c.Parts.Select(p => new
                    {
                        p.Name,
                        p.Price
                    })

                });
            string json = JsonConvert.SerializeObject(cars, Formatting.Indented);
            File.WriteAllText("../../../dataexit/carsWithParts.json",json);
        }

        private static void LocalSuppliers(CarDealerContext context)
        {
            var localSuppliers = context.Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new
                {
                    s.Id,
                    s.Name,
                    partsCount = s.Parts.Count

                });
            string json = JsonConvert.SerializeObject(localSuppliers, Formatting.Indented);
            File.WriteAllText("../../../dataexit/localSuppliers.json",json);
        }


        private static void CarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(c => c.Make == "Toyota")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .Select(c => new
                {
                    c.Id,
                    c.Make,
                    c.Model,
                    c.TravelledDistance

                });
            string json = JsonConvert.SerializeObject(cars, Formatting.Indented);
            File.WriteAllText("../../../dataexit/carsFromModelToyota.json",json);
        }

        private static void SeedData(CarDealerContext context)
        {
            //SeedSupliers(context);
            //SeedParts(context);
            //SeedCars(context);
            //SeedCustomers(context);
            //SeedSales(context);



        }

        private static void OrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .OrderBy(c => c.BirthDate)
                .ThenByDescending(c => c.IsYoungDriver)
                .Select(c => new
                {
                    Id = c.Id,
                    Name = c.Name,
                    IsYoungDriver = c.IsYoungDriver,
                    BirthDay = c.BirthDate,
                    Sales = c.Sales.Select(s => new
                    {
                        s.Car.Model,
                        s.Car.Make,
                        s.Discount,
                        s.Customer.Name,
                        s.Customer.BirthDate,
                        s.Customer.IsYoungDriver
                    })

                });
            string json = JsonConvert.SerializeObject(customers, Formatting.Indented);
            File.WriteAllText("../../../dataexit/orderedCustomers.json", json);
            Console.WriteLine(json);
            

        }

        private static void SeedSales(CarDealerContext context)
        {
            var cars = context.Cars.ToList();
            var customers = context.Customers.ToList();
            Random rnd=new Random();
            double[] discounts = {0, 0.5, 0.10, 0.15, 0.20, 0.30, 0.40, 0.50};
            //new double[] { 0, 0.5, 0.10, 0.15, 0.20, 0.30, 0.40, 0.50 };
            for (int i = 0; i < 50; i++)
            {
                var car = cars[rnd.Next(cars.Count)];
                var customer = customers[rnd.Next(customers.Count)];
                var discount = discounts[rnd.Next(discounts.Length)];
                if (customer.IsYoungDriver)
                {
                    discount += 0.05;
                }

                Sale sale=new Sale
                {
                    Discount = discount,
                    Car = car,
                    Customer = customer
                };
                context.Sales.Add(sale);
                context.SaveChanges();
            }

        }

        

        private static void SeedCustomers(CarDealerContext context)
        {
            string json = File.ReadAllText("../../../datasets/customers.json");
            IEnumerable<Customer> customers = JsonConvert.DeserializeObject<IEnumerable<Customer>>(json);
            context.Customers.AddRange(customers);
            context.SaveChanges();
        }

        private static void SeedCars(CarDealerContext context)
        {
            string json = File.ReadAllText("../../../datasets/cars.json");
            IEnumerable<Car> cars = JsonConvert.DeserializeObject<IEnumerable<Car>>(json);
            Random rnd=new Random();
            var parts = context.Parts.ToList();
            int RandomPartsCount = rnd.Next(10, 21);
            foreach (var car in cars)
            {
                for (int i = 0; i < RandomPartsCount; i++)
                {
                    car.Parts.Add(parts[rnd.Next(parts.Count)]);
                }
                context.Cars.Add(car);
            }
            context.SaveChanges();
        }


        private static void SeedSupliers(CarDealerContext context)
        {
            string json = File.ReadAllText("../../../datasets/suppliers.json");
            IEnumerable<Supplier> suppliers = JsonConvert.DeserializeObject<IEnumerable<Supplier>>(json);
            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();
        }

        private static void SeedParts(CarDealerContext context)
        {
            string json = File.ReadAllText("../../../datasets/parts.json");
            IEnumerable<Part> parts = JsonConvert.DeserializeObject<IEnumerable<Part>>(json);
            Random rnd=new Random();
            var suppliers = context.Suppliers.ToList();
            foreach (var part in parts)
            {
                part.Supplier = suppliers[rnd.Next(suppliers.Count)];
            }
            context.Parts.AddRange(parts);
            context.SaveChanges();
        }
    }
}
