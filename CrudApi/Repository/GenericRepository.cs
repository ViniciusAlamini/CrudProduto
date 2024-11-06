using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CrudApi.DB;
using CrudApi.Interface;
using Microsoft.EntityFrameworkCore;

namespace CrudApi.Models
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        protected readonly ProdutoContext _context;

        public GenericRepository(ProdutoContext context)
        {
            _context = context;
        }
        public async Task Delete(T entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<T> Salvar(T entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _context.Add(entity);
            }
            else
            {
                _context.Update(entity);
            }
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Update(T entity)
        {

            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> BuscarPorId(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> SelecionarTodos()
        {
            return await _context.Set<T>().ToListAsync();
        }

    }
}