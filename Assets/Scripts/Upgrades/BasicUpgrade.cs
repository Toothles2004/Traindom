using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicUpgrade : BasicInteractable
{
    protected int _UpgradeLevel = 1;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        _Cost = 15;
    }

    protected override void InteractEffect()
    {
        _UpgradeLevel += 1;
        _Cost += 5*_UpgradeLevel;
    }
}
