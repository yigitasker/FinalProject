using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity,TContext>: IEntityRepository<TEntity>                  // evrensel bir kod oluşturuyoruz. burda bana neyle çalışacağımı ver, hangi context yapısı ile çalışacağımı ver diyoruz.
        where TEntity: class, IEntity, new()                                                             // koşullar
        where TContext: DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using (TContext context = new TContext())                  // database objesi oluşturuyoruz. using işlemi iş bitince bellekte yer tutulmaması için nesneyi siler
            {
                var addedEntity = context.Entry(entity);                              //  addedEntity = ekleyeceğimiz varlık, context.Entry(entity) = gönderdiğim product(entity) için database de referans tut
                addedEntity.State = EntityState.Added;                                // durumunu bildirdiğim nesneyi eklemeyi talep ettim.
                context.SaveChanges();                                                // yaptıklarımı kaydet yani ekle.
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())                  // using işlemi iş bitince bellekte yer tutulmaması için nesneyi siler
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);                             // SingleOrDefault => tek veri getiriyor.
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)               // filtre verebilir vermeyedebilir filter null çünkü
        {
            using (TContext context = new TContext())
            {
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();     // filtre null ise yani filtre yoksa product(veritabanındaki) ta bulunan tüm veriyi list e çevir dedik. : => filtre null değilse filtre varsa filtre uygula onu listele onu gönder dedik.

            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())                  // using işlemi iş bitince bellekte yer tutulmaması için nesneyi siler
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
