using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;
using ProductsShop.Models;
using ProductsShop.Models.Utilities;
using ProductShop.Data;

namespace ProductShopXML.Client
{
    class Program
    {

        // private const string path = "../../../xmldatasets/users.xml";
        // private const string path = "../../../xmldatasets/categories.xml";
       // private const string path = "../../../xmldatasets/products.xml";
        static void Main()
        {
            ProductShopContext context=new ProductShopContext();
           // context.Database.Initialize(true);
         //   var xml = XDocument.Load(path);
            // var users = xml.XPathSelectElements("users/user");
            //foreach (var user in users)
            //{
            //    ImportUsers(user, context);
            //}

            //var products = xml.XPathSelectElements("products/product");
            //foreach (var product in products)
            //{
            //    ImportProducts(product, context);
            //}

            //var categories = xml.XPathSelectElements("categories/category");
            //foreach (var category in categories)
            //{
            //    ImportCategory(category, context);

            //}

            //Task 1
           // ProductsInRange(context);

            //Task 2
           // SuccessfullySoldProducts(context);

            //Task 3
           // CategoriesByProductsCount(context);

            //Task 4
            UsersAndProducts(context);

        }

        private static void UsersAndProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Count > 0)
                .OrderByDescending(u => u.ProductsSold.Count)
                .ThenBy(u => u.LastName)
                .Select(u => new
                {
                    u.FirstName,
                    u.LastName,
                    u.Age,
                    products = u.ProductsSold.Select(p => new
                    {
                        p.Name,
                        p.Price
                    })
                });
            XElement root=new XElement("users");
            root.Add(new XAttribute("count",users.Count()));
            foreach (var user in users)
            {
                XElement userEl=new XElement("user");
                userEl.Add(new XAttribute("first-name",user.FirstName));
                userEl.Add(new XAttribute("last-name", user.LastName));
                userEl.Add(new XAttribute("age", user.Age));
                XElement soldProducts = new XElement("sold-products");
                soldProducts.Add(new XAttribute("count", user.products.Count()));
                foreach (var product in user.products)
                {


                    XElement productEL = new XElement("product");
                    productEL.Add(new XAttribute("name", product.Name));
                    productEL.Add(new XAttribute("price", product.Price));
                    //soldProducts.Add(new XElement("name",product.Name));
                    //soldProducts.Add(new XElement("price",product.Price));
                    //userEl.Add(soldProducts);
                    soldProducts.Add(productEL);
                }
                userEl.Add(soldProducts);
                root.Add(userEl);
            }

            root.Save("../../../results/usersAndProducts.xml");
            context.SaveChanges();
        }

        private static void CategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .OrderBy(c => c.Products.Count())
                .Select(c => new
                {
                    c.Name,
                    numberOfProducts = c.Products.Count,
                    averagePrice = c.Products.Average(p => p.Price),
                    totalRevenue = c.Products.Sum(p => p.Price)

                });
            XElement root=new XElement("categories");
            foreach (var category in categories)
            {
              XElement categoryEl=new XElement("category");
                categoryEl.Add(new XAttribute("name",category.Name));
                categoryEl.Add(new XElement("products-count",category.numberOfProducts));
                categoryEl.Add(new XElement("average-price",category.averagePrice));
                categoryEl.Add(new XElement("total-revenue", category.totalRevenue));
                root.Add(categoryEl);
            }
            root.Save("../../../results/categoriesByProductsCount.xml");
            context.SaveChanges();
        }

        private static void SuccessfullySoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Count(p => p.Buyer!= null)!=0)
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new
                {
                    u.FirstName,
                    u.LastName,
                    soldProducts = u.ProductsSold.Select(p => new
                    {
                        p.Name,
                        p.Price,
                        buyerFirsName=p.Buyer.FirstName,
                        buyerLastName=p.Buyer.LastName
                    })

                });


            XElement root=new XElement("users");
            foreach (var user in users)
            {
                XElement userEl=new XElement("user");
                userEl.Add(new XAttribute("first-name",user.FirstName));
                userEl.Add(new XAttribute("last-name",user.LastName));
                XElement soldProducts=new XElement("sold-products");
                userEl.Add(soldProducts);
                foreach (var product in user.soldProducts)
                {
                    XElement productEl=new XElement("product");
                    productEl.Add(new XElement("name",product.Name));
                    productEl.Add(new XElement("price",product.Price));
                    productEl.Add(new XElement("buyer-first-name",product.buyerFirsName));
                    productEl.Add(new XElement("buyer-last-name",product.buyerLastName));
                    soldProducts.Add(productEl);
                }
               
                root.Add(userEl);
            }
            root.Save("../../../results/successfullySoldProducts1.xml");
        }

        private static void ProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(p => p.Price > 500 && p.Price < 1000 && p.BuyerId == null)
                .OrderBy(p => p.Price)
                .Select(p => new
                {
                    p.Name,
                    p.Price,
                    saller = p.Seller.FirstName + " " + p.Seller.LastName
                });

            XElement root=new XElement("products");
            foreach (var product in products)
            {
                XElement productEl=new XElement("product");
                productEl.Add(new XAttribute("name",product.Name));
                productEl.Add(new XAttribute("price",product.Price));
                productEl.Add(new XAttribute("seller",product.saller));
                root.Add(productEl);

                // Console.WriteLine($"{product.Name} {product.Price} {product.saller}");
            }
            root.Save("../../../results/productsInRange.xml");

        }

        private static void ImportCategory(XElement categoryNode, ProductShopContext context)
        {
            var name = categoryNode.Element("name");
            if (name==null)
            {
                Console.WriteLine(Constants.ImportErrorMessage);
                return;
            }
            var categoryEntity = new Category
            {
                Name = name.Value
            };
            if (categoryEntity.Name==null)
            {
                Console.WriteLine(Constants.ImportErrorMessage);
                return;
            }
            context.Categories.Add(categoryEntity);
            context.SaveChanges();
            Console.WriteLine(Constants.ImportUnnamedEntitySuccessMessage);


        }

        private static void ImportProducts(XElement productNode, ProductShopContext context)
        {
            var name = productNode.Element("name");
            var price=productNode.Element("price");
            if (name==null||price==null)
            {
                Console.WriteLine(Constants.ImportErrorMessage);
                return;
            }
            var productEntity=new Product
            {
                Name = name.Value,
                Price =Decimal.Parse(price.Value,CultureInfo.InvariantCulture)
            };

            if (productEntity.Name==null||productEntity.Price==null)
            {
                Console.WriteLine(Constants.ImportErrorMessage);
                return;
            }
            Random rnd=new Random();

            var users = context.Users.ToList();

            productEntity.Seller = users[rnd.Next(0, users.Count)];

            int countBuyer = rnd.Next(0, users.Count);
            if (countBuyer%2==0)
            {
                productEntity.Buyer = users[rnd.Next(0, users.Count)];
            }

           // var categories = context.Products.ToList();
            int countOfCategories = context.Categories.Count();
            for (int i = 1; i < rnd.Next(1,5); i++)
            {
                Category category = context.Categories.Find(rnd.Next(1, countOfCategories + 1));
                productEntity.Categories.Add(category);
            }
            context.Products.Add(productEntity);
            context.SaveChanges();
            Console.WriteLine(Constants.ImportNamedEntitySuccessMessage);
        }


        private static void ImportUsers(XElement userNode, ProductShopContext context)
        {
           var fName=userNode.Attribute("first-name");
            var lName = userNode.Attribute("last-name");
            var age = userNode.Attribute("age");


            if (fName==null||lName==null||age==null)
            {
                Console.WriteLine(Constants.ImportErrorMessage);
                return;
            }
            var userEntity=new User
            {
                FirstName   = fName.Value,
                LastName = lName.Value,
                Age = int.Parse(age.Value)
            };
            if (userEntity.FirstName==null||userEntity.LastName==null||userEntity.Age==null)
            {
                Console.WriteLine(Constants.ImportErrorMessage);
                return;
            }
            context.Users.Add(userEntity);
            Console.WriteLine(Constants.ImportUnnamedEntitySuccessMessage);
            context.SaveChanges();
        }
    }
}
