using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
//using System;

//[Serializable]
//public class TestData :
//    {

//}
public class BasicDrone : MonoBehaviour
{
    [SerializeField]
    protected float _InteractCooldown = 1.0f;
    protected float _InteractTimer = 0.0f;
    protected bool _TargetReached = false;

    protected float _SqrInteractRange = 1;

    protected GameObject _TargetPos = null;
    protected Rigidbody _RigidBody = null;

    [SerializeField]
    protected float _MovementSpeed = 1.0f;

    protected GameObject[] _GameObjects;

    protected float _Distance = 0;

    private void Awake()
    {
        _RigidBody = GetComponent<Rigidbody>();
        //DontDestroyOnLoad(this);
    }

    protected virtual void Update()
    {
        if (_InteractTimer < _InteractCooldown)
        {
            _InteractTimer += Time.deltaTime;
        }

        if(!_TargetReached)
        {
            MoveToTarget();
            CheckTargetReached();
        }
        else
        {
            _RigidBody.velocity = Vector3.zero;
            _RigidBody.angularVelocity = Vector3.zero;
            _RigidBody.constraints.Equals(RigidbodyConstraints.FreezeAll);
        }
    }

    public virtual void MoveToTarget()
    {
        if(_TargetPos != null )
        {
            if (_RigidBody == null) return;

            float speed = 0;
            _Distance = _TargetPos.transform.position.x - _RigidBody.position.x;

            if(_Distance < 0)
            {
                speed = _MovementSpeed * (-1);
            }
            else
            {
                speed = _MovementSpeed;
            }

            Vector3 movement = new Vector3(speed, 0.0f, 0.0f);
            _RigidBody.velocity = movement;
        }
    }
    public virtual void ChangeCooldown()
    {

    }

    public virtual void GetClosestPosTarget()
    {
        float closestInteractable = float.PositiveInfinity;
        int closestIndex = -1;

        for (int index = 0; index < _GameObjects.Length; ++index)
        {
            float distance = (_RigidBody.transform.position - _GameObjects[index].transform.position).sqrMagnitude;
            if (distance < closestInteractable)
            {
                closestInteractable = distance;
                closestIndex = index;
            }
        }
        if (closestIndex == -1) return;

        Debug.Log(closestInteractable);

        _TargetPos = _GameObjects[closestIndex];
    }

    public bool CheckTargetReached()
    {
        if ((_Distance > 0) && (_Distance <= _SqrInteractRange))
        {
            _TargetReached = true;
            return true;
        }
        return false;
    }
}


