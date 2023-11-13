using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehavior : MonoBehaviour
{
    private LayerMask _LayerMask = -1;

    protected const float _AttackRange = 3.0f;

    protected int _Damage = 2;
    
    public bool _Attacking = false;

    // Start is called before the first frame update
    void Start()
    {
        _LayerMask = LayerMask.GetMask("Wall") | LayerMask.GetMask("EndLevel") | LayerMask.GetMask("Drone");
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Attack()
    {
        _Attacking = false;
        // Use the objects hit collidor to check for overlap
        // If the target has a health component and it is alive then damage it and set attacking to true
        Collider[] hitColliders = Physics.OverlapBox(gameObject.transform.position, transform.localScale * 1.5f, Quaternion.identity, _LayerMask);
        for (int index = 0; index < hitColliders.Length; ++index)
        {
            //Debug.Log("Hit : " + hitColliders[index].name + index);
            Health targetHealth = hitColliders[index].GetComponent<Health>();
            if (targetHealth != null)
            {
                if(targetHealth.GetAlive())
                {
                    targetHealth.Damage(_Damage);
                    _Attacking = true;
                }
            }
        }
    }
}
