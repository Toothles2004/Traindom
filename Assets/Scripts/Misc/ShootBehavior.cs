using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBehavior : MonoBehaviour
{
    [SerializeField]
    private GameObject _GunTemplate = null;

    [SerializeField]
    private GameObject _Socket = null;

    private BasicWeapon _Weapon = null;
    

    private void Awake()
    {
        //spawn guns
        if(_GunTemplate != null && _Socket != null)
        {
            var gunObject = Instantiate(_GunTemplate, _Socket.transform, true);
            gunObject.transform.localPosition = Vector3.zero;
            gunObject.transform.localRotation = Quaternion.identity;
            _Weapon = gunObject.GetComponent<BasicWeapon>();
        }
    }
}
