using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehavior : MonoBehaviour
{
    protected int TARGET_MASK = -1;
    public int TargetMask 
    {
        get { return TARGET_MASK; }
        set { TARGET_MASK = value; }
    }

    protected const float _AttackRange = 100.0f;

    protected int _Damage = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack()
    {
        if(TargetMask == -1)
        {
            return;
        }

        RaycastHit hit; 
        if(Physics.Raycast(transform.position + (Vector3.up / 2.0f), transform.right, out hit, _AttackRange, LayerMask.GetMask("EndLevelObject")))
        {
            hit.collider.GetComponent<Health>().Damage(_Damage);
        }
        Debug.DrawRay(transform.position + (Vector3.up / 2.0f), transform.right * _AttackRange,Color.red,1.0f);
    }
}
