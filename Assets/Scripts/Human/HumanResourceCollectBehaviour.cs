using Assets.Scripts.System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanResourceCollectBehaviour : MonoBehaviour
{
    private HumanBehaviour _humanBehaviour;

    void Start()
    {
        _humanBehaviour = GetComponent<HumanBehaviour>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Collision: {collision.gameObject.name}");


        if (collision.transform.CompareTag("Ammunition"))
        {
            if (_humanBehaviour.Human.IsWeaponExist)
                return;

            var ammunition = collision.transform.GetComponent<AmmunitionPack>();
            var ammunitionData = ammunition.GetAmmunition();
            
            var weaponController = FactoryController.CreateWeaponController(ammunitionData.Item1[0], _humanBehaviour.Human.Human);
            _humanBehaviour.Human.AddWeapon(weaponController);
            PostWeaponAddedEvent(weaponController);
            ammunition.DestroyOnCollision();
        }
    }

    private void PostWeaponAddedEvent(WeaponController weaponController)
    {
        EventAggregator.Post(_humanBehaviour, new WeaponAddedEvent() { Owner = _humanBehaviour, Weapon = weaponController });
    }
}
