using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicInteractable : MonoBehaviour
{
    [SerializeField]
    private float _InteractCooldown = 1.0f;
    private float _InteractTimer = 0.0f;
    protected PlayerCharacter _Player = null;

    protected int _Cost = 3;
    protected int _InteractCounter = 0;

    protected virtual void Start()
    {
        _Player = FindAnyObjectByType<PlayerCharacter>();
    }
    protected virtual void Update()
    {
        if(_InteractTimer < _InteractCooldown)
        {
            _InteractTimer += Time.deltaTime;
        }
        //Debug.Log(_InteractTimer);
    }

    virtual public void Interact()
    {
        if(_InteractTimer < _InteractCooldown)
        {
            return;
        }
        if (!_Player.ConsumeCrystal(_Cost))
        {
            return;
        }
        InteractEffect();
        _InteractTimer = 0.0f;
    }

    virtual protected void InteractEffect()
    {

    }
}
