﻿using MyLibrary.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDomain.Entities
{
    [Table("departments")]
    public class Department : DBEntity
    {
        [Column("name")]
        [StringLength(64)]
        public string Name { get; set; }
        public List<Employee> Employees { get; set;}
    }
}
