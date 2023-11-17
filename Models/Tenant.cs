using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BlazorDemo.Models
{
    public class Tenant
    {
        [Key]
        public int Id { get; set; }

        public string Key {get;set;} = null!;
        public string Name {get;set;} = null!;
        public string Host {get;set;} = null!;
        public DateTimeOffset Created {get;set;}
        
    }
}