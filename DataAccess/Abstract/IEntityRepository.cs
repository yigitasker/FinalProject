using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    // generic constraint = gerenic kısıt
    // class : referans tip
    // IEntity : IEntity olabilir veya IEntity iplemente eden bir nesne olabilir.
    // new() : new lenebilir olmalı
    public interface IEntityRepository<T> where T:class,IEntity, new()                    // T ye atanan değerleri kısıtlamış olduk. yani atanan değer Ientity olcak veya onu implemente olan değerler olcak. tabi ınretfaceler newlwnwmz olduğu için artık IEntity nesnesi gndermeyiz artık sadec unu implemente eden değerler çalışıor.                     
    {
        List<T> GetAll(Expression<Func<T,bool>> filter = null);                   // filterler yazmamı sağlayan bir koddur. ıd sine göre geti gibi...

        T Get(Expression<Func<T, bool>> filter);                   

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        // List<T> GetAllByCategory(int categoryId);                           // yukarıdaki işlemerlle beraber bu işleme gerek kalmadı.
    }
}
