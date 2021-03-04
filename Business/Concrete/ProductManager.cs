using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.CCS;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        ICategoryService _categoryService;

        public ProductManager(IProductDal productDal,ICategoryService categoryService)                 // constructor, yani ProductManager new lendiğinde bana IProductDal referansı ver yani onu implemente eden(InMemeroy,EntityFramework,..) değerlernden birini ver demiş oluyorum.
        {

            _productDal = productDal;
            _categoryService = categoryService;
            
        }

        [SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]                              // IProductService teki bütüm Get leri sil demek
        public IResult Add(Product product)
        {
            // Business codes = iş için grekli olan kurallardır örneiğin bir ürün yüklerden bir katagoride max 10 ürün olabilir diyor mesela bizde burda aşılmışmı aşılamaış diye denetliyoruz.




            // Bir katagoride en fazla 10 ürün olabilir;
            // Eğer mevcut kategori sayısı 15'i geçtiyse sisteme yeni ürün eklenemez.
            IResult result = BusinessRules.Run(CheckIfProductNameExists(product.ProductName), CheckIfProductCountOfCategoryCorrect(product.CategoryId),CheckIfCategoryLimitExceded());        // hata veriyormu vermiyormu denetliyoruz


            if (result != null)
            {
                return result;
            }

            _productDal.Add(product);

            return new SuccessResult(Messages.ProductAdded);


                               


        }

        [CacheAspect]    //key,value              // tekrar tekrar databes den veri çağırmamaız sağlar bir kere çağırılan veri cach te tutlur bir daha çağırılırsa veri tabanına gitmeden cache den çağırabiliriz
        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour == 3)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductsListed);                              // IProductDal içindeki GetAll çalıştırılabildi. çünkü constructor yolu ile miras aldı.



        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));

        }


        [CacheAspect]
        //[PerformanceAspect(5)]
        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }


        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;
            if (result>= 15)
            {
                return new ErrorResult(Messages.ProductCounToCategoryError);
            }
            return new SuccessResult();
        }


        private IResult CheckIfProductNameExists(string productName)
        {
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();       // bool döner varmı yokumu bakar.
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }
            return new SuccessResult();
        }


        private IResult CheckIfCategoryLimitExceded()
        {
            var result = _categoryService.GetAll();
            if (result.Data.Count>15)
            {
                return new ErrorResult(Messages.CategoryLimitExceded);
            }
            return new SuccessResult();
        }


        //[TransactionalScopeAspect]
        public IResult AddTransactionalTest(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
