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
        if (!_Health.GetAlive())
        {
            for (int index = 0; index < _AttachedBuilderDrones.Count; index++)
            {
                PlaceDrone(_AttachedBuilderDrones[index], index);
            }
            for (int index = 0; index < _AttachedFighterDrones.Count; index++)
            {
                PlaceDrone(_AttachedFighterDrones[index], index);
            }
        }
        else
        {
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
    }

    private void DestroyWall()
    {
        transform.position = OriginalPos - new Vector3(0, 3.1f, 0);
    }

    private void BuildWall()
    {
        transform.position = OriginalPos;
        _Health.SetAlive(true);
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
        PlaceDrone(drone, _AttachedBuilderDrones.Count - 1);
    }
    
    private void AttachFighterDrone(FighterDrone drone)
    {
        _AttachedFighterDrones.Add(drone);
        PlaceDrone(drone, _AttachedFighterDrones.Count - 1);
    }

    private void PlaceDrone(BasicDrone drone, int index)
    {
        Vector3 dronePos = transform.position + (transform.up * 3.5f) - (transform.forward * 2.5f);
        dronePos += (transform.forward * ((index) % 5)) + (transform.up * (int)(index / 5));
        drone.transform.position = dronePos;
    }
}
