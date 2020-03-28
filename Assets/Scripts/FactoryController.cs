using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryController : MonoBehaviour
{
    private static FactoryController I;
    [SerializeField] private MainGameDataHolder dataHolder;

    private void Awake()
    {
        I = this;
    }

    public static WeaponController CreateWeaponController(WeaponTypeBullet weaponType, HumanModel human)
    {
        return I.GetWeaponController(weaponType, human);
    }

    public WeaponController GetWeaponController(WeaponTypeBullet weaponType, HumanModel human)
    {
        var weaponModel = MainGameDataHolder.GetWeaponModel(weaponType);
        return new WeaponController(weaponModel, human);
    }

    public static HumanController CreateHumanController(HumanModel human, IShootable shootable)
    {
        return I.CreateHuman(human, shootable);
    }

    public HumanController CreateHuman(HumanModel human, IShootable shootable)
    {
        var humanController = new HumanController(human, shootable);
        return humanController;
    }
}
