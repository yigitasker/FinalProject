
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    // generic constraint = gerenic kısıt
    // class : referans tip
    // IEntity : IEntity olabilir veya IEntity iplemente eden bir nesne olabilir.
    // new() : new lenebilir olmalı
    public interface IEntityRepository<T> where T:class,IEntity, new()                    // T ye atanan değerleri kısıtlamış olduk. yani atanan değer Ientity olcak veya onu implemente olan değerler olcak. tabi ınretfaceler newlwnwmz olduğu için artık IEntity nesnesi gndermeyiz artık sadec unu implemente eden değerler çalışıor.                     
    {
        List<T> GetAll(Expression<Func<T,bool>> filter = null);                   // filterler yazmamı sağlayan bir koddur. ıd sine göre getir gibi... çoklu değer getimek için filtre vermesede olur demek

        T Get(Expression<Func<T, bool>> filter);                                // bir veri getir. bu yapı operasyonu kullanırken operasyon içinde filtreleme yapmamızı sağlayacak.

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        // List<T> GetAllByCategory(int categoryId);                           // yukarıdaki işlemerlle beraber bu işleme gerek kalmadı.
    }
}
