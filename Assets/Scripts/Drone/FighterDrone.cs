using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterDrone : BasicDrone
{
    private ShootBehavior _ShootBehavior;
    private Health _DroneHealth = null;
    private float _StoredHealth = 0;

    // Start is called before the first frame update
    void Start()
    { 
        _ShootBehavior = GetComponent<ShootBehavior>();
        _GameObjects = GameObject.FindGameObjectsWithTag("Construct");
        GetClosestPosTarget();
        _TargetPos.GetComponent<Wall>().AddFighterDrone(this);
        _DroneHealth = GetComponent<Health>();
        _InteractCooldown = 0.5f;
        if(_DroneHealth != null)
        {
            _StoredHealth = _DroneHealth.GetHealth();
        }
    }

    // Update is called once per frame
    protected override void Update()
    {
        // Heal Drone over time if it has not been attacked
        base.Update();
        if ((_InteractTimer >= _InteractCooldown) && (_DroneHealth != null))
        {
            if(_StoredHealth != _DroneHealth.GetHealth())
            {
                _InteractTimer = -1;
                _StoredHealth = _DroneHealth.GetHealth();
            }
            else
            {
                _DroneHealth.Heal(2);
                _InteractTimer = 0;
            }
        }
    }
}
