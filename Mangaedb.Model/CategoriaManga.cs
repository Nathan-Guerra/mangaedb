// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Mangaedb.Model
{
    [Table("categoria_manga")]
    [Index("IdCategoria", "IdManga", Name = "UK_CategoriaManga", IsUnique = true)]
    public partial class CategoriaManga
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("id_categoria")]
        public int IdCategoria { get; set; }
        [Column("id_manga")]
        public int IdManga { get; set; }

        [ForeignKey("IdCategoria")]
        [InverseProperty("CategoriaManga")]
        public virtual Categoria IdCategoriaNavigation { get; set; }
        [ForeignKey("IdManga")]
        [InverseProperty("CategoriaManga")]
        public virtual Manga IdMangaNavigation { get; set; }
    }
}