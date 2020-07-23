using System;
using Xunit;
using ProjectTest.Domain;
using ProjectTest.Domain.IService;
using ProjectTest.Domain.Service;
using ProjectTest.Domain.Entity;

namespace ProjectTest.Test
{
    public class TestFight
    {
        IFightService _fightService;
        public TestFight()
        {
            _fightService = new FightService();
            
        }

      
        [Fact]
        public void TestSentDamage()
        {
            Character c1 = new Character(true, 1000);
            Character c2 = new Character(true, 1000);
            double damage = 10;

            var resul = _fightService.SetDamage(damage,c1,c2);
        }


        [Fact]
        public void SetHeal()
        {
            Character c1 = new Character(true, 1000);
            Character c2 = new Character(true, 1000);
            int levelHeal = 10;

            var resul = _fightService.SetHeal(levelHeal, c1, c2);
        }


        [Fact]
        public void isDiferentCharacter()
        {
            Character c1 = new Character(true, 1000);
            Character c2 = new Character(true, 1000);

            var resul = _fightService.isDiferentCharacter( c1, c2);
        }

        [Fact]
        public void RangeFightIsOk()
        {

            string typeFight = "melee";
            Character c1 = new Character(true, 1000);
            Character c2 = new Character(true, 1000);
            c1.RangeChoice = 1;
            c2.RangeChoice = 2;
            var resul = _fightService.RangeFightIsOk(typeFight,c1.RangeChoice, c2.RangeChoice);
        }

        [Fact]
        public void IsAllies()
        {

            
            Character c1 = new Character(true, 1000);
            Character c2 = new Character(true, 1000);
            c1.RangeChoice = 1;
            c2.RangeChoice = 2;

            Factions f = new Factions();
            f.Name = "F1";
            c1.Factions.Add(f);
            c2.Factions.Add(f);

            var resul = _fightService.IsAllies(c1, c2);
        }


        [Fact]
        public void JoinFaction()
        {

            Character c1 = new Character(true,1000);            
            Factions f = new Factions();
            f.Name = "F1";
            c1.RangeChoice = 1;
            var resul = _fightService.JoinFaction(f,c1);
        }

        [Fact]
        public void LeaveFaction()
        {

            Character c1 = new Character(true,1000);
            Factions f = new Factions();
            f.Name = "F1";
            c1.RangeChoice = 1;
            var resulJoin = _fightService.JoinFaction(f, c1);

            Factions factionLeave = _fightService.GetFaction(c1.Factions[0].Guid, c1);
            var resul = _fightService.JoinFaction(factionLeave, c1);
        }

      




    }
}
