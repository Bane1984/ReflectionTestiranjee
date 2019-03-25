using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ReflectionTestiranje.Models
{
    public class Knjiga
    {
        [Key]
        public int Id { get; set; }
        public string Naslov { get; set; }
        public string Opis { get; set; }
        public DateTime Izdata { get; set; }

        public Autor Autor { get; set; }
        [ForeignKey("AutorId")]
        public string AutorId { get; set; }
    }
}
