using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractBehavior : MonoBehaviour
{
    [SerializeField]
    private float _sqrInteractRange = 3;

    private GameObject[] _gameObjects;
    public void Awake()
    {
        _gameObjects = GameObject.FindGameObjectsWithTag("Interactable");
    }

    public void Interact()
    {
        _gameObjects = GameObject.FindGameObjectsWithTag("Interactable");

        float closestInteractable = float.PositiveInfinity;
        int closestIndex = -1;

        for (int i = 0; i < _gameObjects.Length; i++)
        {
            float distance = (transform.position - _gameObjects[i].transform.position).sqrMagnitude;
            if(distance < closestInteractable)
            {
                closestInteractable = distance;
                closestIndex = i;
            }
        }

        if (closestIndex == -1) return;

        Debug.Log(closestInteractable);
        
        if(closestInteractable <= _sqrInteractRange)
        {
            _gameObjects[closestIndex].GetComponent<BasicInteractable>().Interact();
        }
    }
}
