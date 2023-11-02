using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private WallHealth _Health = null;
    private Renderer _Renderer = null;
    // Start is called before the first frame update
    void Start()
    {
        _Renderer = GetComponentInChildren<Renderer>();
        _Health = GetComponent<WallHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_Health.GetAlive())
        {
            _Renderer.enabled = false;
        }
        else
        {
            _Renderer.enabled = true;
        }
    }
}
