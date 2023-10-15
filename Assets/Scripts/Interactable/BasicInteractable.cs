using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicInteractable : MonoBehaviour
{
    [SerializeField]
    private float _InteractCooldown = 1.0f;
    private float _InteractTimer = 0.0f;
    protected bool _DoInteract = false;
    protected virtual void Update()
    {
        if(_InteractTimer < _InteractCooldown)
        {
            _InteractTimer += Time.deltaTime;
        }
        Debug.Log(_InteractTimer);
    }

    virtual public void Interact()
    {
        if(_InteractTimer < _InteractCooldown)
        {
            _DoInteract = false;
            return;
        }

        _DoInteract = true;
        _InteractTimer = 0.0f;
    }
}
