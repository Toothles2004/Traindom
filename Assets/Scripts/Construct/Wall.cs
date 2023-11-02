using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private WallHealth _Health = null;

    public bool _start = false;
    
    // Start is called before the first frame update
    void Start()
    {
        _Health = GetComponent<WallHealth>();
        _Health.OnWallDestroy += DestroyWall;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void DestroyWall()
    {
        transform.position -= new Vector3(0, 3.1f, 0);
    }
}
