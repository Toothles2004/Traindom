using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField]
    protected Image _HealthBarSprite;

    [SerializeField]
    protected float _MaxHealth = 15;
    protected float _CurrentHealth = 1;
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

    // Apply damage to the object and update the health bar
    public void Damage(int amount)
    {
        _CurrentHealth -= amount;
        _HealthBarSprite.fillAmount = _CurrentHealth / _MaxHealth;
        //Debug.Log(_HealthBarSprite.fillAmount);
        if ( _CurrentHealth <= 0 )
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

    public void IncreaseMaxHealth(float amount)
    {
        _MaxHealth += amount;
    }

    // Heal the object and update the health bar
    public void Heal(float amount)
    {
        _CurrentHealth += amount;
        if (_CurrentHealth > _MaxHealth)
        {
            _CurrentHealth = _MaxHealth;
        }
        _HealthBarSprite.fillAmount = _CurrentHealth / _MaxHealth;
    }

    public float GetHealth()
    {
        return _CurrentHealth;
    }
}
