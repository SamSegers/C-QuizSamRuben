using EindopdrachtProg5RubenSam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EindopdrachtProg5RubenSam
{
    class Vraag
    {
        public string Naam { get; set; }
        public string Categorie { get; set; }
        public int Id { get; set; }
        public IEnumerable<Antwoord> Antwoorden { get; set; }
    }
}
