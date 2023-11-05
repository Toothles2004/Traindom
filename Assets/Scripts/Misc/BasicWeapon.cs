using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicWeapon : MonoBehaviour
{
    [SerializeField]
    private GameObject _BulletTemplate = null;

    private float _FireRate = 1.0f;

    [SerializeField]
    private List<Transform> _FireSockets = new List<Transform>();
    private float _FireTimer = 0.0f;

    private Transform _Enemy = null;

    private float _Range = 40.0f;

    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0.0f, 0.2f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= _Range)
        {
            _Enemy = nearestEnemy.transform;
        }
        else
        {
            _Enemy = null;
        }
    }
    void Update()
    {
        // Handle the countdown of fire timer
        if( _FireTimer > 0.0f)
        {
            _FireTimer -= Time.deltaTime;
        }

        if (_Enemy == null)
        {
            return;
        }

        if (_FireTimer <= 0.0f)
        {
            FireProjectile();
        }

        //// Target lock on
        transform.LookAt(_Enemy.position);
    }

    private void FireProjectile()
    {
        // No bullet to fire
        if(_BulletTemplate == null)
        {
            return;
        }

        for(int index = 0; index < _FireSockets.Count; ++index)
        {
            Instantiate(_BulletTemplate, _FireSockets[index].position, _FireSockets[index].rotation);
        }

        // Set the time so we respect the firerate
        _FireTimer += 1.0f / _FireRate;
    }
}
