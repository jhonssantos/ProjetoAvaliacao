using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTest.Domain.Entity
{
    public class Character
    {
        public Guid Guid { get; set; }
        public int Health { get; set; }

        public double Level { get; set; }
        public bool Alive { get; set; }
        public int RangeChoice { get; set; }

        public List<Factions> Factions { get; set; }

        public bool IsCharacter { get; set; }
        public Character(bool isCharacter, int health)
        {
            if (isCharacter)
            {
                Health = 1000;
            }
            else
            {
                Health = health;
            }

            IsCharacter = isCharacter;
            Guid = Guid.NewGuid();            
            Level = 1;
            Alive = true;
            Factions = new List<Factions>();
        }

    }
}
