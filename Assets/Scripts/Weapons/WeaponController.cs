using Assets.Scripts.System;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponState
{
    ReadyToFire,
    InReload
}

public class WeaponController 
{
    private int _totalBulletInClipCounter;
    private int _totalBulletCounter;
    private float _reloadTimeCounter;
    public WeaponModel Weapon { get; }
    private HumanModel _owner;

    public WeaponTypeBullet WeaponType => Weapon.WeaponType;

    public HumanModel Owner => _owner;
    public int BulletInClip => _totalBulletInClipCounter;
    public int TotalBullet => _totalBulletCounter;
    private WeaponState _weaponState = WeaponState.ReadyToFire;
    private bool _shootAgain = true;

    public event Action<BulletShootInfo> OnFire;

    public WeaponController(WeaponModel weapon, HumanModel human)
    {
        Weapon = weapon;
        _owner = human;
    }

    public bool Fire()
    {
        if (!_shootAgain)
            return false;

        if (_weaponState == WeaponState.InReload)
            return false;

        if (_totalBulletInClipCounter <= 0 && _totalBulletCounter > 0)
        {
            Reload();
            return false;
        }

        SetShootAgain(false);
        _totalBulletInClipCounter--;

        if (_totalBulletInClipCounter == 0)
        {
            if (_totalBulletCounter > 0)
            {
                Reload();
            }
            else
            {
                return false;
            }
        }
        CoroutineBehaviour.DelayedAction(Weapon.FireRate, () => SetShootAgain(true));
        RaiseOnShootEvent();
        return true;

    }
    public void FireUp()
    {
        SetShootAgain(true);
    }

    private void SetShootAgain(bool shootAgain)
    {
        _shootAgain = shootAgain;
    }
    public void AddBullet(int count)
    {
        _totalBulletCounter += count;
        if (_totalBulletCounter > Weapon.MaxBulletCount)
        {
            _totalBulletCounter = Weapon.MaxBulletCount;
        }
    }

    public void Reload()
    {
        ChangeWeaponState(WeaponState.InReload);
        var bulletCount = Mathf.Min(_totalBulletCounter, Weapon.Capacity);
        _totalBulletCounter -= bulletCount;
        _totalBulletInClipCounter = bulletCount;
        CoroutineBehaviour.DelayedAction(Weapon.ReloadTime, ReloadComplete);
    }

    private void ReloadComplete()
    {
        ChangeWeaponState(WeaponState.ReadyToFire);
        SetShootAgain(true);
    }
    private void ChangeWeaponState(WeaponState state)
    {
        _weaponState = state;
    }

    private void RaiseOnShootEvent()
    {
        var shootInfo = new BulletShootInfo()
        {
            Bullet = Weapon.Bullet,
            Owner = _owner
        };

        OnFire?.Invoke(shootInfo);
        EventAggregator.Post(this, shootInfo);
    }
}
