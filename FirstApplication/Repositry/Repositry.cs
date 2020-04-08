using System;
using System.Collections.Generic;

namespace FirstApplication.Repositry{

    public class Repositry<T, ID> : IRepositry<T, ID> where T:class
    {
      

        private  List<T> List {get; set;} = new List<T>();

      
   


        public void Delete(Predicate<T> id)
        {
            T data = this.List.Find(id);
            List.Remove(data);
        }

       

        public IEnumerable<T> GetAll()
        {
            return this.List;
        }

        public T GetByID(Predicate<T> id)
        {
             return List.Find(id);
        }

 

        public T Insert(T obj)
        {
           List.Add(obj);
           return obj;
        }

        
        public void Update(Predicate<T> id, T obj)
        {
            T data = List.Find(id);
            data=obj;
        }
    }

}