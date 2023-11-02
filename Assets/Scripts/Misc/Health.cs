using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int _MaxHealth = 15;
    private int _CurrentHealth = 1;
    private bool _Alive = true;

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
            _Alive = false;
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
    public virtual void SetAlive()
    {
        _Alive = false; ;
    }
}
