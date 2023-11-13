using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalUpgrade : BasicUpgrade
{
    private BasicCrystal _Crystal = null;
    protected override void Start()
    {
        base.Start();
        _Crystal = GetComponent<BasicCrystal>();
    }
    protected override void InteractEffect()
    {
        base.InteractEffect();
        UpgradeMiningSpeed();
    }
    protected void UpgradeMiningSpeed()
    {
        _Crystal._MineTimer *= 0.6f;
        //Debug.Log("Current mining speed");
        //Debug.Log(_Crystal._MineTimer);
    }
}
