using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTest.Domain.Entity
{
    public class Factions
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }

        public Factions()
        {
            Guid = Guid.NewGuid();
        }
    }
}
