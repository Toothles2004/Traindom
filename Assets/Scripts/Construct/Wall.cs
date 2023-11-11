using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UIElements;

public class Wall : MonoBehaviour
{
    public WallHealth _Health = null;
    public bool _start = false;
    private Vector3 OriginalPos = Vector3.zero;

    private List<BuilderDrone> _BuilderDrones = new List<BuilderDrone>();
    private List<BuilderDrone> _AttachedBuilderDrones = new List<BuilderDrone>();
    private List<FighterDrone> _FighterDrones = new List<FighterDrone>();
    private List<FighterDrone> _AttachedFighterDrones = new List<FighterDrone>();

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
        RemoveDrone();
        for (int index = 0; index < _BuilderDrones.Count; ++index)
        {
            if (_BuilderDrones[index].CheckTargetReached())
            {
              AttachBuilderDrone(_BuilderDrones[index]);
              _BuilderDrones.RemoveAt(index);
            }
        }
        for (int index = 0; index < _FighterDrones.Count; ++index)
        {
            if (_FighterDrones[index].CheckTargetReached())
            {
              AttachFighterDrone(_FighterDrones[index]);
              _FighterDrones.RemoveAt(index);
            }
        }
    }

    private void DestroyWall()
    {
        transform.position = OriginalPos - new Vector3(0, 3.1f, 0);
        for (int index = 0; index < _AttachedBuilderDrones.Count; index++)
        {
            PlaceBuilderDrone(_AttachedBuilderDrones[index], index);
        }
        for (int index = 0; index < _AttachedFighterDrones.Count; index++)
        {
            PlaceFighterDrone(_AttachedFighterDrones[index], index);
        }
        //Debug.Log("Wall destroyed");
    }

    private void BuildWall()
    {
        transform.position = OriginalPos;
        _Health.SetAlive(true);
        for (int index = 0; index < _AttachedBuilderDrones.Count; index++)
        {
            PlaceBuilderDrone(_AttachedBuilderDrones[index], index);
        }
        for (int index = 0; index < _AttachedFighterDrones.Count; index++)
        {
            PlaceFighterDrone(_AttachedFighterDrones[index], index);
        }
    }

    public void AddBuilderDrone(BuilderDrone drone)
    {
        _BuilderDrones.Add(drone);
    }
    
    public void AddFighterDrone(FighterDrone drone)
    {
        _FighterDrones.Add(drone);
    }

    private void AttachBuilderDrone(BuilderDrone drone)
    {
        _AttachedBuilderDrones.Add(drone);
        PlaceBuilderDrone(drone, _AttachedBuilderDrones.Count - 1);
    }
    
    private void AttachFighterDrone(FighterDrone drone)
    {
        _AttachedFighterDrones.Add(drone);
        PlaceFighterDrone(drone, _AttachedFighterDrones.Count - 1);
    }

    private void PlaceFighterDrone(FighterDrone drone, int index)
    {
        Vector3 dronePos = transform.position + (transform.up * 3.5f) - (transform.forward * 2.0f);
        dronePos += (transform.forward * (index % 5)) + (transform.up * (index / 5));
        drone.transform.position = dronePos;
    }

    private void PlaceBuilderDrone(BuilderDrone drone, int index)
    {
        Vector3 dronePos = transform.position - (Vector3.forward * 2.6f) - (transform.up * 0.75f);
        dronePos += (transform.up + new Vector3(0.0f, 0.5f * index, 0.0f));
        drone.transform.position = dronePos;
        drone.transform.rotation = new Quaternion( -45.0f, 0.0f, 0.0f, 45.0f);
    }

    private void RemoveDrone()
    {
        for (int index = 0; index < _AttachedFighterDrones.Count; index++)
        {
            if(_AttachedFighterDrones[index] == null)
            {
                _AttachedFighterDrones.RemoveAt(index);
            }
        }
    }
}
