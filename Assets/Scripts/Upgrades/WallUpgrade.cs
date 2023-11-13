using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
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
        if(_Wall == null)
        {
            return;
        }

        base.InteractEffect();
        UpgradeMaxHealth();
    }
    protected void UpgradeMaxHealth()
    {
        _Wall._Health.IncreaseMaxHealth(10);
        //Debug.Log("Current health");
        //Debug.Log(_Wall._Health._MaxHealth);
        //Debug.Log("Current cost");
        //Debug.Log(_Cost);
    }
}
