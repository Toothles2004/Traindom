using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicProjectile : MonoBehaviour
{
    private float _Speed = 6.0f;

    [SerializeField]
    private float _LifeTime = 5.0f;

    [SerializeField]
    private int _Damage = 1;

    private const string KILL_METHOD = "Kill";

    private void Awake()
    {
        Invoke(KILL_METHOD, _LifeTime);
    }

    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * _Speed;
    }

    public void Kill()
    {
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        Health targetHealth = collision.rigidbody.GetComponent<Health>();
        if(targetHealth != null)
        {
            targetHealth.Damage(_Damage);
        }
        //if(collision.gameObject.layer == LayerMask.GetMask("Enemy"))
        //{
        //    collision.rigidbody.GetComponent<Health>().Damage(_Damage);
        //}
        Kill();
    }
}
