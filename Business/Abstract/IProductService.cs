using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService               // iş katmanında kullanacağımız servis operasyonları
    {
        IDataResult<List<Product>> GetAll();                    // tüm ürünleri listeleyecek bir ortam oluşturdum. IDataResult u işlem sonu veya kullanıcıya mesaj vermek içinkuşllansığım ınterafece  

        IDataResult<List<Product>> GetAllByCategoryId(int id);

        IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max);
        IDataResult<List<ProductDetailDto>> GetProductDetails();

        IResult Add(Product product);                          // bişey döndürmez.

        IDataResult<Product> GetById(int productId);                  // bir product döndürüyor.
    }
}
