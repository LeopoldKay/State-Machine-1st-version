using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameDataHolder : MonoBehaviour
{
    private static MainGameDataHolder I;
    
    [SerializeField] private List<WeaponModel> _weapons;
    [SerializeField] private List<HumanModel> _humans;
    [SerializeField] private List<WeaponPrefabData> _weaponPrefabDataList;
    [SerializeField] private List<BulletPrefabData> _bulletPrefabDataList;
    [SerializeField] private List<WeaponCrosshairData> _weaponCrosshairDataList;

    [SerializeField] private SpawnPointsBehaviour _humanSpawnPoints;
    [SerializeField] private SpawnPointsBehaviour _ammunitionSpawnPoints;

   

    private void Awake()
    {
        I = this;
    }

    public static BulletPrefabData GetBulletPrefabData(WeaponTypeBullet bullet)
    {
        return I.GetBulletPrefabDataInner(bullet);
    }

    public BulletPrefabData GetBulletPrefabDataInner(WeaponTypeBullet bulletType)
    {
        var result = _bulletPrefabDataList.Find(bullet => bullet.Bullet == bulletType);
        return result;
    }

    public static WeaponModel GetWeaponModel(WeaponTypeBullet weaponType)
    {
        return I.GetWeaponModelInner(weaponType);
    }

    public WeaponModel GetWeaponModelInner(WeaponTypeBullet weaponType)
    {
        var result = _weapons.Find(model => model.WeaponType == weaponType);
        return result;
    }

    public static HumanModel GetHumanModel(ControllingType controllingType)
    {
        return I.GetHumanModelInner(controllingType);
    }

    private HumanModel GetHumanModelInner(ControllingType controllingType)
    {
        var result = _humans.Find(human => human.ControllType == controllingType);
        return result;
    }

    public static WeaponPrefabData GetWeaponPrefabData(WeaponTypeBullet weaponType)
    {
        return I.GetWeaponPrefabDataInner(weaponType);
    }

    public WeaponPrefabData GetWeaponPrefabDataInner(WeaponTypeBullet weaponType)
    {
        var result = _weaponPrefabDataList.Find(weapon => weapon.WeaponType == weaponType);
        return result;
    }

    public static WeaponCrosshairData GetWeaponCrosshairData(WeaponTypeBullet weaponType)
    {
        return I.GetWeaponCrosshairDataInner(weaponType);
    }

    public WeaponCrosshairData GetWeaponCrosshairDataInner(WeaponTypeBullet weapon)
    {
        var result = _weaponCrosshairDataList.Find(crosshairData => crosshairData.WeaponType == weapon);
        return result;
    }

    public static SpawnPointsBehaviour HumanSpawnPoints => I._humanSpawnPoints;
    public static SpawnPointsBehaviour AmminitionSpawnPoints => I._ammunitionSpawnPoints;

}

[Serializable]
public class BulletPrefabData
{
    public WeaponTypeBullet Bullet;
    public BulletBehaviour Prefab;
}

[Serializable]
public class WeaponPrefabData
{
    public WeaponTypeBullet WeaponType;
    public WeaponBehaviour Prefab;
}

[Serializable]
public class WeaponCrosshairData
{
    public WeaponTypeBullet WeaponType;
    public Sprite Crosshair;
}
