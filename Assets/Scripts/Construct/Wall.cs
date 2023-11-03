using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private WallHealth _Health = null;
    public bool _start = false;
    private Vector3 OriginalPos = Vector3.zero;

    private List<BuilderDrone> _BuilderDrones = new List<BuilderDrone>();
    private List<BuilderDrone> _AttachedDrones = new List<BuilderDrone>();

    // Start is called before the first frame update
    void Start()
    {
        OriginalPos = transform.position;
        _Health = GetComponent<WallHealth>();
        _Health.SetAlive(false);

        if (!_Health.GetAlive())
        {
            DestroyWall();
        }
        _Health.OnWallDestroy += DestroyWall;
        _Health.OnWallBuild += BuildWall;
    }

    // Update is called once per frame
    void Update()
    {
        for(int index = 0; index < _BuilderDrones.Count; ++index)
        {
            if (_BuilderDrones[index].CheckTargetReached())
            {
                AttachDrone(_BuilderDrones[index]);
            }
        }
        if (!_Health.GetAlive())
        {
            
        }
    }

    private void DestroyWall()
    {
        transform.position = OriginalPos - new Vector3(0, 3.1f, 0);
    }

    private void BuildWall()
    {
        transform.position = OriginalPos;
    }

    public void AddDrone(BuilderDrone drone)
    {
        _BuilderDrones.Add(drone);
    }

    private void AttachDrone(BuilderDrone drone)
    {
        _AttachedDrones.Add(drone);
    }
}
