using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EindopdrachtProg5RubenSam.Models
{
    class Quiz
    {
        public string Naam { get; set; }
        public int Id { get; set; }
        public IEnumerable<Vraag> Vragen { get; set;}
    }
}
