using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnInteractable : BasicInteractable
{
    [SerializeField]
    private GameObject _SpawnObjectTemplate = null;

    [SerializeField]
    private GameObject _SpawnPoint = null;

    public override void Interact()
    {
        base.Interact();
        if((_DoInteract == false) || (_Player.ConsumeCrystal(_Cost)))
        {
            return;
        }

        Instantiate(_SpawnObjectTemplate, _SpawnPoint.transform.position, _SpawnPoint.transform.rotation);
    }
}
