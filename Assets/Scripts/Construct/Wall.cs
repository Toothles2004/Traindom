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
    private Vector3 _OriginalPos = Vector3.zero;

    private List<BuilderDrone> _BuilderDrones = new List<BuilderDrone>();
    private List<BuilderDrone> _AttachedBuilderDrones = new List<BuilderDrone>();
    private List<FighterDrone> _FighterDrones = new List<FighterDrone>();
    private List<FighterDrone> _AttachedFighterDrones = new List<FighterDrone>();

    // Start is called before the first frame update
    void Start()
    {
        _OriginalPos = transform.position;
        _Health = GetComponent<WallHealth>();
        if( _Health == null )
        {
            return;
        }
        _Health.SetAlive(false);

        if (!_Health.GetAlive())
        {
            DestroyWall();
        }

        // On event call when wall gets killed or built move the wall
        _Health.OnWallDestroy += DestroyWall;
        _Health.OnWallBuild += BuildWall;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if drones need to be removed
        // Loop to check if new drones reach wall and add them to the list
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

    // When the wall gets destroyed move it and the drones attached to it down
    private void DestroyWall()
    {
        transform.position = _OriginalPos - new Vector3(0, 3.1f, 0);
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

    // When the wall gets built move the wall and the drones attached to it up
    private void BuildWall()
    {
        transform.position = _OriginalPos;

        if(_Health != null)
        {
            _Health.SetAlive(true);
        }
        
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

    // Add drone to list and place them in the correct location
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

    // If fighterDrone is dead remove from wall list
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
