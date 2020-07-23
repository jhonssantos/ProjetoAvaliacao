using System;
using System.Collections.Generic;
using System.Text;
using ProjectTest.Domain.Entity;

namespace ProjectTest.Domain.IService
{
    public interface IFightService
    {

        Character SetDamage(double levelDamage, Character characterSend , Character characterRecive );

        Character SetHeal(int levelHeal, Character characterSend, Character characterRecive);

        bool isDiferentCharacter(Character characterSend, Character characterRecive);

        bool RangeFightIsOk(string typeFight, int rangeCharacter1, int rangeCharacter2);

        bool IsAllies(Character characterSend, Character characterRecive);

        Character  JoinFaction(Factions fac, Character character);


        Character  LeaveFaction(Factions fac, Character character);

        Factions GetFaction(Guid fac, Character character);
    }
}
