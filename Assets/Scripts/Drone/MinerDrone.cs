using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinerDrone : BasicDrone
{
    // Start is called before the first frame update
    void Start()
    {
        _GameObjects = GameObject.FindGameObjectsWithTag("Crystal");
        GetClosestPosTarget();
        _TargetPos.GetComponent<BasicCrystal>().AddMinerDrone(this);
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    public override void GetClosestPosTarget()
    {
        // Check which crystal is located the closest
        float closestInteractable = float.PositiveInfinity;
        int closestIndex = -1;

        if(_GameObjects == null)
        {
            return;
        }

        for (int index = 0; index < _GameObjects.Length; ++index)
        {
            float distance = (_RigidBody.transform.position - _GameObjects[index].transform.position).sqrMagnitude;
            if ((distance < closestInteractable) && (_GameObjects[index].GetComponent<BasicCrystal>().CheckIfSlotsAvailable()))
            {
                closestInteractable = distance;
                closestIndex = index;
            }
        }
        if (closestIndex == -1) return;

        Debug.Log(closestInteractable);

        _TargetPos = _GameObjects[closestIndex];
        _GameObjects[closestIndex].GetComponent<BasicCrystal>().UpdateSlotsUsed();
    }
}