using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudApi.DB
{
    public partial class ProdutoContext : DbContext
    {
        private readonly IConfiguration _configuracaoAppSettings;
        public ProdutoContext(DbContextOptions<ProdutoContext> options, IConfiguration configuracaoAppSettings) : base(options) { 
            _configuracaoAppSettings = configuracaoAppSettings;
        }

        public virtual DbSet<Produto> Produtos { get; set;}


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuracaoAppSettings.GetConnectionString("DefaultConnection"));
        }
    }
}