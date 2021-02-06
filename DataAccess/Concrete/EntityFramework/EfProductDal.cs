using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    // NuGet = kütüphane 
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal                    // Veritabanı operasyonlarını yazmaya hazırız
    {
        public List<ProductDetailDto> GetProductDetails()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from p in context.Products                       // ürünlerdeki ürünlerle kategorileri join et demek
                             join c in context.Categories
                             on p.CategoryId equals c.CategoryId              // koşul
                             select new ProductDetailDto
                             {
                                 ProductId = p.ProductId,
                                 ProductName = p.ProductName,
                                 CategoryName = c.CategoryName,
                                 UnitsInstock = p.UnitsInStock
                             };
                return result.ToList();
                            
            }               

        }
    }
}
