using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField] private WeaponTypeBullet BulletType;
    private BulletModel _bulletModel;
    private bool _isActive;

    private BulletShootInfo _bulletShootInfo;

    public void Init(BulletShootInfo bulletShootInfo)
    {
        _bulletShootInfo = bulletShootInfo;
        _bulletModel = _bulletShootInfo.Bullet;
        _isActive = true;
    }

    
    void Start()
    {
        
    }

    
    void Update()
    {
        if (!_isActive)
            return;

        if (_bulletModel.VisualType != WeaponTypeBullet.RPG_7)
        {
            CheckHit();
        }
    }

    private void CheckHit()
    {
        Debug.Log("- On Shot -");
    }
}

public class BulletShootInfo
{
    public BulletModel Bullet;
    public HumanModel Owner;
}
