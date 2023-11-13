using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float _Cooldown = 10.0f;
    private float _Timer = 0.0f;
    private int _EnemyAmount = 0;
    private int _CurrentWave = 0;
    private float _SpawnDelay = 0.4f;

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
            _CurrentWave += 1;
            _Timer = 0.0f;
            _EnemyAmount = Random.Range(1, _CurrentWave);
            for(int index = 0; index < _EnemyAmount; ++index)
            {
                Invoke("SpawnEnemy", index*_SpawnDelay);
            }
        }
    }

    private void SpawnEnemy()
    {
        Instantiate(_Template, transform);
    }
}
