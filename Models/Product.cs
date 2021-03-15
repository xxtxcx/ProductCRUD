using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductCRUD.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }     // идентификатор
        [Column(TypeName = 'nvarchar(50)')]
        public string Name { get; set; }    // название 
        [Column(TypeName = 'nvarchar(20)')]
        public string Company { get; set; } // производитель
        [Column(TypeName = 'nvarchar(6)')]
        public int Price { get; set; }  // цена
        [Column(TypeName = 'nvarchar(20)')]
        public string MadeIn { get; set; } // страна-произведитель


    }
}
