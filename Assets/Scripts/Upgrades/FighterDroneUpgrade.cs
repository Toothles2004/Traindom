using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FighterDroneUpgrade : BasicUpgrade
{
    private BasicWeapon _Weapon = null;
    private float _NewFireRate = 0.0f;

    protected override void Start()
    {
        base.Start();
    }
    protected override void InteractEffect()
    {
        base.InteractEffect();
        _Weapon = FindObjectOfType<BasicWeapon>();

        if( _Weapon == null )
        {
            return;
        }

        _NewFireRate = 1.0f * Mathf.Pow(0.6f, _UpgradeLevel);
        UpgradeShootingSpeed();
    }
    protected void UpgradeShootingSpeed()
    {
        _Weapon.SetFireRate(_NewFireRate);
        //Debug.Log("new firerate");
        //Debug.Log(_Weapon.GetFireRate());
    }
}
