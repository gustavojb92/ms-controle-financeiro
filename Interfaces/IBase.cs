using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ms_controle_financeiro.Interfaces
{
    public interface IBase<in T, out A>
    {
        IEnumerable<A> GetAll();

        A GetById(int id);

        A Post(T obj);
        Boolean Delete(int Id);

    }
}