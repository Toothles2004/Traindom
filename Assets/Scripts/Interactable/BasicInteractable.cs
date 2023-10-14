using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicInteractable : MonoBehaviour
{
    virtual public void Interact()
    {
        transform.position += Vector3.up * 5;
    }
}
