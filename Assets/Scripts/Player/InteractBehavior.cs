using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractBehavior : MonoBehaviour
{
    [SerializeField]
    private float _SqrInteractRange = 3;

    private GameObject[] _GameObjects;
    public void Awake()
    {
        _GameObjects = GameObject.FindGameObjectsWithTag("Interactable");
    }

    public void Interact()
    {
        float closestInteractable = float.PositiveInfinity;
        int closestIndex = -1;

        for (int index = 0; index < _GameObjects.Length; ++index)
        {
            float distance = (transform.position - _GameObjects[index].transform.position).sqrMagnitude;
            if(distance < closestInteractable)
            {
                closestInteractable = distance;
                closestIndex = index;
            }
        }

        if (closestIndex == -1) return;

        //Debug.Log(closestInteractable);
        
        if(closestInteractable <= _SqrInteractRange)
        {
            _GameObjects[closestIndex].GetComponent<BasicInteractable>().Interact();
        }
    }
}
