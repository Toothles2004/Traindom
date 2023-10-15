using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnInteractable : BasicInteractable
{
    [SerializeField]
    private GameObject _SpawnObjectTemplate = null;

    [SerializeField]
    private GameObject _spawnPoint = null;

    public override void Interact()
    {
        base.Interact();
        if(_DoInteract == false)
        {
            return;
        }

        Instantiate(_SpawnObjectTemplate, _spawnPoint.transform.position, _spawnPoint.transform.rotation);
    }
}
