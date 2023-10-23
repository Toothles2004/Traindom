using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicCharacter : MonoBehaviour
{
    protected MovementBehavior _MovementBehavior;

    // start is called before the first frame update
    protected virtual void Awake()
    {
        _MovementBehavior = GetComponent<MovementBehavior>();
    }
}
