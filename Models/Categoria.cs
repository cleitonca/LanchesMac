﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanchesMac.Models
{
    [Table("Categorias")]
    public class Categoria
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o nome da categoria.")]
        [StringLength(100, ErrorMessage = "O tamanho máximo é de 100 caracteres.")]
        [Display(Name = "Nome")]
        public string CategoriaNome { get; set; }

        [Required(ErrorMessage = "Informe a descrição da categoria.")]
        [StringLength(200, ErrorMessage = "O tamanho máximo é de 200 caracteres.")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        public List<Lanche> Lanches { get; set; }

    }
}
