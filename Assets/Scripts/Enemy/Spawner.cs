using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float _Cooldown = 10.0f;
    private float _Timer = 0.0f;

    [SerializeField]
    private GameObject _Template = null;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(_Timer < _Cooldown)
        {
            _Timer += Time.deltaTime;
        }
        else
        {
            _Timer = 0.0f;
            SpawnEnemy();
            _Cooldown *= 0.9f;
        }
    }

    private void SpawnEnemy()
    {
        Instantiate(_Template, transform);
    }
}
