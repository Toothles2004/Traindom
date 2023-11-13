using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BasicInteractable : MonoBehaviour
{
    [SerializeField]
    protected float _InteractCooldown = 1.0f;
    protected float _InteractTimer = 0.0f;
    protected PlayerCharacter _Player = null;

    [SerializeField]
    protected int _Cost = 3;
    protected int _InteractCounter = 0;

    protected TextMeshProUGUI _UpgradeCost = null;

    protected virtual void Start()
    {
        _Player = FindAnyObjectByType<PlayerCharacter>();
        _UpgradeCost = GetComponentInChildren<TextMeshProUGUI>();

        if(_UpgradeCost != null )
        {
            _UpgradeCost.text = _Cost.ToString();
        }
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

        // If the player has enough crystals to interact call interactEffect and reset the timer
        if (!_Player.ConsumeCrystal(_Cost) || (_Player == null))
        {
            return;
        }
        InteractEffect();
        _InteractTimer = 0.0f;
    }

    virtual protected void InteractEffect()
    {
        if (_UpgradeCost == null)
        {
            return;
        }
        _UpgradeCost.text = _Cost.ToString();
    }
}
