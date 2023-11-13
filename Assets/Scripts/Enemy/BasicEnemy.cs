using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class BasicEnemy : BasicCharacter
{
    protected AttackBehavior _AttackBehavior;

    private float _AttackTimer = 0.0f;
    private float _AttackCooldown = 1.0f;
    private GameObject _Target = null;

    protected override void Awake()
    {
        base.Awake();
        _AttackBehavior = GetComponent<AttackBehavior>();
        _Target = FindObjectOfType<EndLevelInteractable>().gameObject;
    }

    private void Update()
    {
        if (_AttackBehavior == null)
        {
            return;
        }
        if (_AttackTimer < _AttackCooldown)
        {
            _AttackTimer += Time.deltaTime;
        }
        else
        {
            _AttackBehavior.Attack();
            _AttackTimer = 0.0f;
        }

        // If enemy is attacking a target don't move
        if(!_AttackBehavior._Attacking)
        {
            _MovementBehavior.DesiredMovementDirection = _Target.transform.position - transform.position;
        }
        else
        {
            _MovementBehavior.DesiredMovementDirection = Vector3.zero;
        }
    }
}
