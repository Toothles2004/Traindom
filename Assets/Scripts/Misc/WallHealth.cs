using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WallHealth : Health
{
    public delegate void DestroyWall();
    public event DestroyWall OnWallDestroy; 

    public delegate void BuildWall();
    public event BuildWall OnWallBuild;

    protected override void Start()
    {
        _MaxHealth = 30;
        _CurrentHealth = 0;
        _HealthBarSprite.fillAmount = _CurrentHealth / _MaxHealth;
    }

    protected override void Die()
    {

        OnWallDestroy?.Invoke();
    }

    // Update health bar and when wall reached max health call buildWall
    public void Heal(int health)
    {
        if(_CurrentHealth > _MaxHealth)
        {
            return;
        }

        _CurrentHealth += health;
        if (_CurrentHealth >= _MaxHealth)
        {
            _CurrentHealth = _MaxHealth;
            _HealthBarSprite.fillAmount = _CurrentHealth / _MaxHealth;
            OnWallBuild?.Invoke();
        }
    }
}
