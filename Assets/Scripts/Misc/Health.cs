using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private int _MaxHealth = 15;
    private int _CurrentHealth = 1;

    // Start is called before the first frame update
    void Start()
    {
        _CurrentHealth = _MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(int amount)
    {
        _CurrentHealth -= amount;
        if( _CurrentHealth <= 0 )
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}
