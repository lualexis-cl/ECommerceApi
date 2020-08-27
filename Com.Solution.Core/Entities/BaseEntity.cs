using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Com.Solution.Core.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
