using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProductsShop.Models;
using ProductShop.Data;

namespace ProductShop.Client
{
    class Program
    {
        static void Main()
        {
            ProductShopContext context=new ProductShopContext();
            //context.Database.Initialize(true);
           // SeedUsers(context);
           //SeedProducts(context);
           //SeedCategories(context);
           
            //3.

            //Task 1
           // ProductInRange(context);

            //Task 2
           // SuccessfullySoldProducts(context);

            //Task 3
            //CategoriesByProductsCount(context);

            //Task4
            UsersAndProducts(context);
        }


        private static void UsersAndProducts(ProductShopContext context)
        {
            var usersProducts = context.Users
                .Where(u => u.ProductsSold.Count() > 1)
                .OrderByDescending(u => u.ProductsSold.Count())
                .ThenBy(u => u.LastName)
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    age = u.Age,
                    count=u.ProductsSold.Count(),
                    soldProduct = u.ProductsSold.Select(p => new
                    {
                        name = p.Name,
                        price = p.Price,
                        
                    })
                });
            string jsonObj = JsonConvert.SerializeObject(usersProducts, Formatting.Indented);
            File.WriteAllText("../../../datasets/usersProducts.json", jsonObj);
        }

        private static void CategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .OrderBy(c => c.Products.Count)
                .Select(cat => new
                {
                    name = cat.Name,
                    numberOfProducts = cat.Products.Count(),
                    averagePrice = cat.Products.Average(p => p.Price),
                    totalRevenue = cat.Products.Sum(p => p.Price)


                });
            string jsonObj = JsonConvert.SerializeObject(categories, Formatting.Indented);
            File.WriteAllText("../../../datasets/categoriesProductsCount.json",jsonObj);
        }
        private static void SuccessfullySoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Count(p => p.Buyer != null) != 0)
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    soldProducts = u.ProductsSold.Select(product => new
                    {
                        name = product.Name,
                        price = product.Price,
                        buyerFirstName = product.Buyer.FirstName,
                        buyerLastName = product.Buyer.LastName
                    })
                });
            string jsonObj = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText("../../../datasets/successfullySoldProducts.json",jsonObj);


        }
        private static void ProductInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(p => p.Price > 500 && p.Price < 1000 && p.BuyerId == null)
                .OrderBy(p => p.Price)
                .Select(p => new
                {
                    name=p.Name,
                    price=p.Price,
                    seller=p.Seller.FirstName+" "+p.Seller.LastName

                });

            string jsonProducts = JsonConvert.SerializeObject(products, Formatting.Indented);
            File.WriteAllText("../../../datasets/productsInRange.json",jsonProducts);

            foreach (var product in products)
            {
              Console.WriteLine($"{product.name} {product.price} {product.seller}");   
            }

        }


        private static void SeedCategories(ProductShopContext context)
        {
            string json = File.ReadAllText("../../../datasets/categories.json");
            IEnumerable<Category> categories = JsonConvert.DeserializeObject<IEnumerable<Category>>(json);
            int countOfProducts = context.Products.Count();
            Random rnd=new Random();
            foreach (Category category in categories)
            {
                for (int i = 0; i < countOfProducts/3; i++)
                {
                    Product product = context.Products.Find(rnd.Next(1, countOfProducts + 1));
                    category.Products.Add(product);
                }
                
            }
            context.Categories.AddRange(categories);
            context.SaveChanges();
        }

        private static void SeedUsers(ProductShopContext context)
        {
            string json = File.ReadAllText("../../../datasets/users.json");
            IEnumerable<User> users = JsonConvert.DeserializeObject<IEnumerable<User>>(json);
            context.Users.AddRange(users);
            context.SaveChanges();
        }

        private static void SeedProducts(ProductShopContext context)
        {
            string json = File.ReadAllText("../../../datasets/products.json");
            IEnumerable<Product> products = JsonConvert.DeserializeObject<ICollection<Product>>(json);
            Random rnd=new Random();
            foreach (Product product in products)
            {
                product.SellerId = rnd.Next(1, context.Users.Count() + 1);
                double shouldHaveBuyer = rnd.NextDouble();
                if (shouldHaveBuyer <= 0.7)
                {
                    product.BuyerId = rnd.Next(1, context.Users.Count() + 1);
                }
            }
            context.Products.AddRange(products);
            context.SaveChanges();
        }
    }
}
