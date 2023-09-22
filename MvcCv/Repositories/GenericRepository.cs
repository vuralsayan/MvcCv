using MvcCv.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcCv.Repositories
{
    public class GenericRepository<T> where T : class, new()
    {
        DbCvEntities db = new DbCvEntities();

        public List<T> List()                       // T tipinde bir liste döndürür.
        {
            return db.Set<T>().ToList();           // db.Set<T>() : T tipindeki tabloyu döndürür.
        }

        public void TAdd(T p)                       // T tipinde bir parametre alır.
        {
            db.Set<T>().Add(p);                    // parametreyi T tipindeki tabloya ekle.
            db.SaveChanges();
        }

        public void TDelete(T p)                // T tipinde bir parametre alır.
        {
            db.Set<T>().Remove(p);              // parameteryi T tipindeki tablodan sil.
            db.SaveChanges();
        }

        public T TGet(int id)                   // int tipinde bir parametre alır.
        {
            return db.Set<T>().Find(id);        // parametreyi T tipindeki tablodan bul ve döndür.
        }

        public void TUpdate(T p)                // Update işlemi
        {
            db.SaveChanges();
        }
    }
}