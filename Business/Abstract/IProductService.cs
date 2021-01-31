using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService               // iş katmanında kullanacağımız servis operasyonları
    {
        List<Product> GetAll();                    // tüm ürünleri listeleyecek bir ortam oluşturdum.     
    }
}
