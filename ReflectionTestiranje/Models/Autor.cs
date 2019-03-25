using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReflectionTestiranje.Models
{
    public class Autor
    {
        [Key]
        public int AutorId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }


        public List<Knjiga> Knjige { get; set; }
    }
}
