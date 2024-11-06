using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using CrudApi.Interface;



namespace CrudApi.Models
{
    [Table("produto")]
    public partial class Produto : IEntity
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("nome")]
        public string Nome { get; set; }

        [Column("valor")]
        public decimal Valor { get; set; }

        [Column("setor")]
        public string Setor { get; set; }

    }
}
