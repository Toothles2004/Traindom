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
        AttackEnemies();
        _GameObjects = GameObject.FindGameObjectsWithTag("Interactable");

        float closestInteractable = float.PositiveInfinity;
        int closestIndex = -1;

        for (int i = 0; i < _GameObjects.Length; i++)
        {
            float distance = (transform.position - _GameObjects[i].transform.position).sqrMagnitude;
            if(distance < closestInteractable)
            {
                closestInteractable = distance;
                closestIndex = i;
            }
        }

        if (closestIndex == -1) return;

        //Debug.Log(closestInteractable);
        
        if(closestInteractable <= _SqrInteractRange)
        {
            _GameObjects[closestIndex].GetComponent<BasicInteractable>().Interact();
        }
    }

    public void AttackEnemies()
    {
        GameObject[] tempGameObjects = GameObject.FindGameObjectsWithTag("Enemy");
        float closestInteractable = float.PositiveInfinity;
        int closestIndex = -1;

        for (int i = 0; i < tempGameObjects.Length; i++)
        {
            float distance = (transform.position - tempGameObjects[i].transform.position).sqrMagnitude;
            if (distance < closestInteractable)
            {
                closestInteractable = distance;
                closestIndex = i;
            }
        }

        if (closestIndex == -1) return;

        //Debug.Log(closestInteractable);

        if (closestInteractable <= _SqrInteractRange)
        {
            tempGameObjects[closestIndex].GetComponent<Health>().Damage(10);
        }
    }
}
