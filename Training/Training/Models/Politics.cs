using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Training.Models
{
    public class Politics
    {
        //public Politics()
        //{
        //    Users = new HashSet<Pollsters>();
        //}

        public int Id { get; set; }
        public string PoliticalParty { get; set; }

        //public ICollection<Pollsters> Users { get; set; }
    }
}
