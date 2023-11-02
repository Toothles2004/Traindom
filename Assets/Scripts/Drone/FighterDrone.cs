using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterDrone : BasicDrone
{
    // Start is called before the first frame update
    void Start()
    {
        //_GameObjects = ;
        GetClosestTarget();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
}
