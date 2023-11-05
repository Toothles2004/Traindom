using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterDrone : BasicDrone
{
    private ShootBehavior _ShootBehavior;

    // Start is called before the first frame update
    void Start()
    { 
        _ShootBehavior = GetComponent<ShootBehavior>();
        _GameObjects = GameObject.FindGameObjectsWithTag("Construct");
        GetClosestPosTarget();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
}
