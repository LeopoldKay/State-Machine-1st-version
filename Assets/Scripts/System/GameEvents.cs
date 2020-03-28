using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.System
{
    class GameEvents
    {
    }

    public class HealthPointChangeEvent
    {
        public int HealthPoint;
    }

    public class GameStartEvent
    { }

    public class SpawnButtonClickEvent
    { }

    public class WeaponTakeEvent
    {
        public HumanModel Owner;
        public WeaponModel Weapon;
    }

    public class WeaponAddedEvent
    {
        public HumanBehaviour Owner;
        public WeaponController Weapon;
    }
}
