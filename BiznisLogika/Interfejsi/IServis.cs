using System;
using System.Collections.Generic;

namespace BiznisLogika
{
    public interface IServis<T>
    {
        void Add(T t);
        List<T> GetAll();
        List<T> GetByCondition(Predicate<T> condition);

        T Find(Predicate<T> condition);
    }
}
