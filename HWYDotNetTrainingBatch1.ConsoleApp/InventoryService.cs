using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWYDotNetTrainingBatch1.ConsoleApp
{
    internal class InventoryService
    {

        public void CreatProduct()
        {
            Console.WriteLine("Input Product Name: ");
            string productName = Console.ReadLine()!;

            BeforePrice:
            Console.WriteLine("Input Product Price: ");
            string priceResult = Console.ReadLine()!;

            decimal price;
            bool isDecimal = decimal.TryParse(priceResult, out price);
            if (isDecimal == false)
            {
                Console.WriteLine("Invalid Price");
                goto BeforePrice;
            }

            BeforeQuantity:
            Console.WriteLine("Input Product Quantity");
            string qtyResult = Console.ReadLine()!;

            int qty;
            bool isQty = int.TryParse(qtyResult, out qty);
            if (isQty == false)
            {
                Console.WriteLine("Invalid Quantity");
                goto BeforeQuantity;
            }

            int no = Data.Products.Max(x=> x.Id) +1; // 3+1 = 4
            Data.ProductId = no;

            string productCode = "P" + Data.ProductId.ToString().PadLeft(3, '0');
            Product product = new Product(Data.ProductId, productCode, productName, price, qty, "Fruit");
            Data.Products.Add(product);

            Console.WriteLine("Product Insert Successfully");
        }

        public void ViewProducts()
        {
            Console.WriteLine("Product List");
            foreach (var product in Data.Products)
            {
                Console.WriteLine($"Id: {product.Id}, Code: {product.Code}, Name: {product.Name}, Price: {product.Price}, Quantity: {product.Quantity}, Category: {product.Category}");
            }
        }
    }
}
