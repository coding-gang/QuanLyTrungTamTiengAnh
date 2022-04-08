﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.GenericRepositorys
{
   public interface IGenericRepository<T> where T : class
    { 
       IEnumerable<T> GetAll();
       T GetById(object id);
       bool Add(T item);
       bool Update(object id);
       bool Delete(object id);
    }
}
