using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudApi.Interface
{
    public interface IGenericRepository<T>
    {
        Task<IEnumerable<T>> SelecionarTodos();

        Task<T> BuscarPorId(int id);

        Task<T> Salvar(T entity);

        Task Delete(T entity);
    }
}