using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WallHealth : Health
{
    public delegate void DestroyWall();
    public event DestroyWall OnWallDestroy;
    protected override void Die()
    {
        OnWallDestroy?.Invoke();
    }
}
