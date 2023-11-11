using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class InteractBehavior : MonoBehaviour
{
    [SerializeField]
    private float _SqrInteractRange = 3;

    private GameObject[] _GameObjects;
    public void Awake()
    {
        var array1 = GameObject.FindGameObjectsWithTag("Interactable");
        var array2 = GameObject.FindGameObjectsWithTag("Construct");
        var array3 = GameObject.FindGameObjectsWithTag("Crystal");
        var array4 = GameObject.FindGameObjectsWithTag("FighterDroneUpgrade");
        var array5 = array1.Concat(array2).ToArray();
        var array6 = array5.Concat(array3).ToArray();
        _GameObjects = array6.Concat(array4).ToArray();
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
            if(_GameObjects[closestIndex].tag == "Interactable")
            {
                _GameObjects[closestIndex].GetComponent<BasicInteractable>().Interact();
            }
            if(_GameObjects[closestIndex].tag == "Construct")
            {
                _GameObjects[closestIndex].GetComponent<WallUpgrade>().Interact();
            }
            if (_GameObjects[closestIndex].tag == "Crystal")
            {
                _GameObjects[closestIndex].GetComponent<CrystalUpgrade>().Interact();
            }
            if (_GameObjects[closestIndex].tag == "FighterDroneUpgrade")
            {
                _GameObjects[closestIndex].GetComponent<FighterDroneUpgrade>().Interact();
            }
        }
    }
}
