using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EindopdrachtProg5RubenSam
{
    public partial class Context : DbContext
    {
        public Context()
            : base("name=EindopdrachtQuizDbEntities")
        {
            //DbContext D = new DbContext();
        }

        // namen raar gedaan ivm database
        public virtual DbSet<Quiz> Quizen { get; set; }
        public virtual DbSet<Vraag> Vragen { get; set; }
        public virtual DbSet<Antwoord> Antwoorden { get; set; }
    }
}
