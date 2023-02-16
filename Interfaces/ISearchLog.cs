using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ms_controle_financeiro.Interfaces
{
    public interface ISearchLog<in A, out T>
    {
        IEnumerable<T> Search(A obj);
    }
}