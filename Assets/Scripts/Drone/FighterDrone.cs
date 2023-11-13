using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterDrone : BasicDrone
{
    private ShootBehavior _ShootBehavior;
    private Health _DroneHealth = null;
    private bool _BeingAttacked = false;

    // Start is called before the first frame update
    void Start()
    { 
        _ShootBehavior = GetComponent<ShootBehavior>();
        _GameObjects = GameObject.FindGameObjectsWithTag("Construct");
        GetClosestPosTarget();
        _TargetPos.GetComponent<Wall>().AddFighterDrone(this);
        _DroneHealth = GetComponent<Health>();
        _InteractCooldown = 0.5f;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (_InteractTimer < _InteractCooldown)
        {
            _InteractTimer += Time.deltaTime;
        }
        if ((_InteractTimer >= _InteractCooldown) && !_BeingAttacked)
        {
            _DroneHealth.Heal(2);
            _InteractTimer = 0;
        }
    }
}
