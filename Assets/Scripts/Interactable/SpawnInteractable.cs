using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnInteractable : BasicInteractable
{
    [SerializeField]
    private GameObject _SpawnObjectTemplate = null;

    [SerializeField]
    private GameObject _SpawnPoint = null;

    // Spawn the connected drone and increase the price for the next drone
    protected override void InteractEffect()
    {
        Instantiate(_SpawnObjectTemplate, _SpawnPoint.transform.position, _SpawnPoint.transform.rotation);
        _InteractCounter += 1;
        _Cost += 2 * _InteractCounter;
        base.InteractEffect();
    }
}
