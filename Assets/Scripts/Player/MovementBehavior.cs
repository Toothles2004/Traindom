using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehavior : MonoBehaviour
{
    [SerializeField]
    private float _MovementSpeed = 1.0f;

    private Rigidbody _RigidBody;

    private Vector3 _DesiredMovementDirection = Vector3.zero;

    public Vector3 DesiredMovementDirection
    {
        get { return _DesiredMovementDirection; }
        set { _DesiredMovementDirection = value; }
    }

    private void Awake()
    {
        _RigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        if (_RigidBody == null) return;

        Vector3 movement = _DesiredMovementDirection.normalized;
        movement *= _MovementSpeed;

        movement.y = _RigidBody.velocity.y;
        _RigidBody.velocity = movement;
    }
}
