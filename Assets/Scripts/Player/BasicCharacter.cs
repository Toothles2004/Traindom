using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicCharacter : MonoBehaviour
{
    protected MovementBehavior _movementBehavior;
    protected InteractBehavior _interactBehavior;

    // start is called before the first frame update
    protected virtual void Awake()
    {
        _interactBehavior = GetComponent<InteractBehavior>();
        _movementBehavior = GetComponent<MovementBehavior>();
    }
}
