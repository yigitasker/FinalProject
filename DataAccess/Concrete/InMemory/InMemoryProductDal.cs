using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory                             // yapay bir varitabanına ekleme sistemi oluşturduk. bellekte datamız verda onu yönetiyormuş gibi simüle edicez
{

    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;                                 // ürün listesi oluşturduk. global değerler alt çizgi ile verilir.



        public InMemoryProductDal()                             // bellekte referans oluşturulduğunda çalışiacak olan yer. constructor
        {
            
            // Oracle,Sql,Server,Postgres,MongoDB ürün listemiz buralardan birinden geliyormuş gibi simüle ettik.
            
            _products = new List<Product> {                     // products, list tipinde oluşturulan listenin referansını tutacak. içinde de product tipinde ürünlerimiz oluşturduk.           
                new Product{ProductId=1, CategoryId=1,ProductName="Bardak",UnitPrice=15,UnitsInStock=15},
                new Product{ProductId=2, CategoryId=1,ProductName="Kamera",UnitPrice=500,UnitsInStock=3},
                new Product{ProductId=3, CategoryId=2,ProductName="Telefon",UnitPrice=1500,UnitsInStock=2},
                new Product{ProductId=4, CategoryId=2,ProductName="Klavye",UnitPrice=150,UnitsInStock=65},
                new Product{ProductId=5, CategoryId=2,ProductName="Fare",UnitPrice=85,UnitsInStock=1}
            };
        }



        public void Add(Product product)
        {
            _products.Add(product);                              // List in özelliği Add. operasyonun içinde onu kullandık.
        }

        public void Delete(Product product)                       // ben buraya new leyerek bir Product yolluyorum yani yeni bir refrans tutan veri var.
        {
            // _products.Remove(product);                         // _product üzerinden liste elemanlarına gider parantezde gönderdiğimiz değeri arar ancak liste elemanlarının referans tutucu olmalarından dolayı silemez bu durumdan dolayı bu işlem çalışmayaxaktır.






            // Product productToDelete = null;
            //foreach (var p in _products)
            //{
            //    if (product.ProductId == p.ProductId)
            //    {
            //        productToDelete = p;                  productToDelete, p nin referansını tuttu. anlamak için=> p = new Product{ProductId=5, CategoryId=2,..... dır. bu eşitleme ile  productToDelete de aynı referansı tutmuş oldu artık sistem neyi silebileceğini biliyor.  
            //    }
            // }
            //_products.Remove(productToDelete);            productToDelete neyin referansını tuttuğu bilindiği için remove çalışır.               




            // yukardaki yöntem yerine daha kısa bir işlemle işimizi gören LINQ kullanılır;

            // LINQ - Language Integrated Query
            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);                      // bu kod tek tek dolaşamı sağlıyor. her p ye bak... yukardaki foreach te yaptığımız. p takma isim ile elemanları geziyor.

            _products.Remove(productToDelete);


        }

        public List<Product> GetAll()                            
        {
            return _products;                                     // veritabanını olduğu gibi döndürmüş oldum. yani ürünler listemi bana göndermiş oldu.
        }

        public void Update(Product product)
        {
            // gönderdiğim ürün ıd sine sahip olan listedeki ürünü bul demektir
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);

            productToUpdate.ProductName = product.ProductName;          // elimde olan = göndermiş olduğum
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;


        }

        public List<Product> GetAllByCategory(int categoryId)                          
        {   // LINQ
            return _products.Where(p => p.CategoryId == categoryId).ToList();         // Where koşulu içerde şarta uyan bütün elemanları yeni bir liste haline gitirir.
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
