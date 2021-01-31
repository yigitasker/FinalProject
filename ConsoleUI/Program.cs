using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

            ProductManager productManager = new ProductManager(new InMemoryProductDal());              // InMemoryProductDal ın referansını tutabiliyor. (IProductDal)


            foreach (var product in productManager.GetAll())              // InMemoryProductDal içindeki GetAll çalıştı. ve bir liste gönderdi 
            {
                Console.WriteLine(product.ProductName);
            }





        }
    }
}
