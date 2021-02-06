using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IProductDal:IEntityRepository<Product>                 // IProductDal sen bir IEntityRepository sin ve çalışma tipin product dediğim anda IEntityRepository i product a göre yapılandırdık demek oluyor.
    {
        List<ProductDetailDto> GetProductDetails();   
    }
}
