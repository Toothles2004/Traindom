using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinerDrone : BasicDrone
{
    // Start is called before the first frame update
    void Start()
    {
        _GameObjects = GameObject.FindGameObjectsWithTag("Crystal");
        GetClosestTarget();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    public override void GetClosestTarget()
    {
        float closestInteractable = float.PositiveInfinity;
        int closestIndex = -1;

        for (int i = 0; i < _GameObjects.Length; i++)
        {
            float distance = (_RigidBody.transform.position - _GameObjects[i].transform.position).sqrMagnitude;
            if ((distance < closestInteractable) && (_GameObjects[i].GetComponent<BasicCrystal>().CheckIfSlotsAvailable()))
            {
                closestInteractable = distance;
                closestIndex = i;
            }
        }
        if (closestIndex == -1) return;

        Debug.Log(closestInteractable);

        _Target = _GameObjects[closestIndex];
        _GameObjects[closestIndex].GetComponent<BasicCrystal>().UpdateSlotsUsed();
    }
}