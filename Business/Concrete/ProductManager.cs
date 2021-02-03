using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;                                

        public ProductManager(IProductDal productDal)                 // constructor, yani ProductManager new lendiğinde bana IProductDal referansı ver yani onu implemente eden(InMemeroy,EntityFramework,..) değerlernden birini ver demiş oluyorum.
        {
            _productDal = productDal;
        }

        public List<Product> GetAll()
        {
            // iş kodları
            return _productDal.GetAll();                              // IProductDal içindeki GetAll çalıştırılabildi. çünkü constructor yolu ile miras aldı.



        }

        public List<Product> GetAllByCategoryId(int id)
        {
            return _productDal.GetAll(p=>p.CategoryId == id); 

        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);
        }
    }
}
