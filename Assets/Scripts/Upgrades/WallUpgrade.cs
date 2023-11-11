using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallUpgrade : BasicUpgrade
{
    private Wall _Wall = null;
    protected override void Start()
    {
        base.Start();
        _Wall = GetComponent<Wall>();
    }
    protected override void InteractEffect()
    {
        base.InteractEffect();
        UpgradeMaxHealth();
    }
    protected void UpgradeMaxHealth()
    {
        _Wall._Health._MaxHealth += 5;
        //Debug.Log("Current health");
        //Debug.Log(_Wall._Health._MaxHealth);
        //Debug.Log("Current cost");
        //Debug.Log(_Cost);
    }
}
