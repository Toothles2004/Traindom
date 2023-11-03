using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Health : MonoBehaviour
{
    [SerializeField]
    protected int _MaxHealth = 15;
    protected int _CurrentHealth = 1;
    private bool _Alive = true;

    // Start is called before the first frame update
    protected virtual void Start()
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
            _Alive = false;
            _CurrentHealth = 0;
            Die();
        }
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }

    public virtual bool GetAlive()
    {
        return _Alive;
    }
    public virtual void SetAlive(bool alive)
    {
        _Alive = alive;
    }
}
