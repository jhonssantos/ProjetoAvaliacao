using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectTest.Domain.Entity;
using ProjectTest.Domain.IService;
namespace ProjectTest.Domain.Service
{
    public class FightService : IFightService
    {
        public Character SetHeal(int levelHeal,  Character characterSend , Character characterRecive )
        {
            if (CanSetHeal(characterSend, characterRecive))
                return characterRecive;

            if (CanbeHeal(levelHeal, characterRecive))
                characterRecive.Health = characterRecive.Health + levelHeal;

            return characterRecive;
        }


        public Character SetDamage(double levelDamage, Character characterSend, Character characterRecive)
        {
            if (!CanSetDemage(characterSend, characterRecive))
                return characterRecive;


            characterRecive.Level = CalcDemage(levelDamage, characterSend, characterRecive);
            characterRecive.Alive = IsAlive(characterRecive);
            return characterRecive;
        }

        bool CanSetDemage(Character characterSend, Character characterRecive)
        {
            if(((isDiferentCharacter(characterSend, characterRecive) == false) && (IsAllies(characterSend, characterRecive) == false)) || (characterSend.IsCharacter))
            {
                return true;
            }
            return false;
        }

        bool CanSetHeal(Character characterSend, Character characterRecive)
        {
            if ((isDiferentCharacter(characterSend, characterRecive) && (IsAllies(characterSend, characterRecive) == true) && (characterRecive.IsCharacter)) && characterSend.IsCharacter)
            {
                return true;
            }
            return false;
        }


        bool IsAlive(Character character)
        {
            if (character.Level <= 0)
                return false;
            return true;
        }

        bool CanbeHeal(int levelHeal, Character character)
        {
            if ((character.Health + levelHeal > 1000) || character.Alive == false)
                return false;
            return true;
        }

        public bool isDiferentCharacter(Character characterSend, Character characterRecive)
        {
            if (characterSend.Guid != characterRecive.Guid)
                return true;
            return false;
        }

        double CalcDemage(double levelDamage, Character characterSend, Character characterRecive)
        {
            var levelDif = characterSend.Level - characterRecive.Level;
            var calcDamage = ((double)50 / 100) * levelDamage;

            if (levelDif > 5)
                return levelDamage + calcDamage;
            return levelDamage - calcDamage;


        }

        public bool RangeFightIsOk(string typeFight, int rangeCharacter1 , int rangeCharacter2)
        {
            if(typeFight == "melee")
            {
                if(rangeCharacter1 > 2 || rangeCharacter2 > 2)
                {
                    return false;
                }
                return true;
            }
            else
            {
                if (rangeCharacter1 < 20 && rangeCharacter2 < 20)
                    return true;
            }
            return false;

        }

        public bool IsAllies(Character characterSend, Character characterRecive)
        {
            var factionsCharacterSend = characterSend.Factions.ToArray();
            var factionsCharacterRecive = characterRecive.Factions.ToArray();
            
            Factions[] factions = factionsCharacterSend.Concat(factionsCharacterRecive).ToArray();
            var meuHashSet = new HashSet<Factions>(factions);
            var acertos = factions.Length - meuHashSet.Count;
            if (acertos > 0)
                return true;

            return false;

        }

        public Character JoinFaction(Factions fac , Character character)
        {
            if (!character.IsCharacter)
                return character;
            
            character.Factions.Add(fac);
            return character;
        }
        public Character LeaveFaction(Factions fac, Character character)
        {
            character.Factions.Remove(fac);
            return character;
        }

        public Factions GetFaction(Guid fac, Character character)
        {
            var faction = character.Factions.Where(x => x.Guid == fac).FirstOrDefault();
            return faction;
        }


    }
}
