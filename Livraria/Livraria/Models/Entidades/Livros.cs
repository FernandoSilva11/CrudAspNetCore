using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria.Models.Entidades
{
    public class Livros
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Titulo { get; set; }

        [Required]
        [StringLength(300)]
        public string Sinopse { get; set; }

        [DisplayName("Preço")]
        [DataType(DataType.Currency)]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:C2}")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Preco { get; set; }

        public bool EmEstoque { get; set; }

        [StringLength(100)]
        public string Genero { get; set; }

        [Required]
        [StringLength(200)]
        public string Escritor { get; set; }

        [DisplayName("Imagem")]
        [StringLength(400)]
        public string ImagemUrl { get; set; }
    }
}
