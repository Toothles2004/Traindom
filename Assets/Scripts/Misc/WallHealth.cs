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
        _CurrentHealth = 0;
    }

    protected override void Die()
    {

        OnWallDestroy?.Invoke();
    }

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
            OnWallBuild?.Invoke();
        }
    }
}
