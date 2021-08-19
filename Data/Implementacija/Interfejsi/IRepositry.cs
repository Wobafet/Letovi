using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implementacija.Interfejsi
{
   public interface IRepositry<T>
    {
        void Add(T t);

        T Find(Predicate<T> p);

        List<T> FindAll();

        List<T> GetByCondition(Predicate<T> condition);
    }
}
