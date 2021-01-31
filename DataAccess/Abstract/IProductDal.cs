using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IProductDal                 // veritabanı için yapacağım operasyonları barındıracak olan yer olcak.
    {
        List<Product> GetAll();                 // Entities katmanına referans gösterdik. ve içinden Concrete e bağlıntı kurduk.

        void Add(Product product);

        void Update(Product product);

        void Delete(Product product);

        List<Product> GetAllByCategory(int categoryId);                 // categoryıd sine göre filtreleme yapılacak.
    }
}
