using MyLibrary.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyLibrary.Entities
{
    [Table("themes")]
    public class Theme : DbEntity
    {   
        [StringLength(64)]
        [Column("name")]
        [Index("IX_UniqueKeyInt", IsUnique = true, Order = 1)]
        public string Name { get; set; }

        [Column("parrentId")]
        [DefaultValue(null)]
        public Guid? ParrentId { get; set; }

        public List<Book> Books { get; set; }

        public Theme Parrent { get; set; }

    }

}
