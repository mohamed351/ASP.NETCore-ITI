using System.Linq;
using System.Collections.Generic;
using System.Collections;
using System;

namespace FirstApplication.Repositry
{
    public interface IRepositry<T, ID> where T:class
    {

      

         IEnumerable<T> GetAll();

         T GetByID(Predicate<T> id);

         void Delete(Predicate<T> id);

         void Update(Predicate<T> ID , T obj);

         T Insert(T obj);

        
             
        
    }
}