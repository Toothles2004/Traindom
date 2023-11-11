using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnInteractable : BasicInteractable
{
    [SerializeField]
    private GameObject _SpawnObjectTemplate = null;

    [SerializeField]
    private GameObject _SpawnPoint = null;

    protected override void InteractEffect()
    {
        Instantiate(_SpawnObjectTemplate, _SpawnPoint.transform.position, _SpawnPoint.transform.rotation);
        _InteractCounter += 1;
        _Cost += 2 * _InteractCounter;
    }
}
