using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudApi.DB;
using CrudApi.Interface;
using CrudApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudApi.Repository
{
    public class ProdutoRepository : GenericRepository<Produto>, IGenericRepository<Produto>
    {
        public ProdutoRepository(ProdutoContext context) : base(context){}
    }
}