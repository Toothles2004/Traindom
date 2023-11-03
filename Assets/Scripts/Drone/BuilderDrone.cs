using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuilderDrone : BasicDrone
{
    private int _HealingAmount = 2;
    private WallHealth _TargetHealth = null;
    // Start is called before the first frame update
    void Start()
    {
        _GameObjects = GameObject.FindGameObjectsWithTag("Construct");
        GetClosestTarget();
        if(_Target == null )
        {
            return;
        }
        _TargetHealth = _Target.GetComponent<WallHealth>();
        _Target.GetComponent<Wall>().AddDrone(this);
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if(_TargetReached)
        {
            if (_InteractTimer >= _InteractCooldown)
            {
                if (_TargetHealth == null)
                {
                    return;
                }
                _TargetHealth.Heal(_HealingAmount);
                _InteractTimer = 0;
            }
        }
    }
}
