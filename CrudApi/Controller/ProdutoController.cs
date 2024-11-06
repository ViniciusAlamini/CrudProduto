using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudApi.Models;
using CrudApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CrudApi.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : GenericController<Produto>
    {
        protected readonly ProdutoRepository _produtoRepository;

        public ProdutoController(ProdutoRepository produtoRepository) : base(produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        

    }
}