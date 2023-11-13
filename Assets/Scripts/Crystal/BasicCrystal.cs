using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicCrystal : MonoBehaviour
{
    private List<MinerDrone> _MinerDrones = new List<MinerDrone>();
    private List<MinerDrone> _AttachedMinerDrones = new List<MinerDrone>();

    private bool _SlotsAvailable = true;
    private int _AmountOfSlots = 3;
    private int _CurrentSlotsUsed = 0;

    public float _MineCooldown = 3.0f;
    private float _MineTimer = 0.0f;

    private PlayerCharacter _Player = null;

    // Start is called before the first frame update
    private void Start()
    {
        _Player = FindAnyObjectByType<PlayerCharacter>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int index = 0; index < _MinerDrones.Count; ++index)
        {
            if (_MinerDrones[index].CheckTargetReached())
            {
                AttachMinerDrone(_MinerDrones[index]);
                _MinerDrones.RemoveAt(index);
            }
        }
        if (_MineTimer < _MineCooldown)
        {
            _MineTimer += Time.deltaTime;
        }
        else if(_MineTimer >= _MineCooldown)
        {
            MineCrystal();
            _MineTimer = 0.0f;
        }
    }

    public void AddMinerDrone(MinerDrone drone)
    {
        _MinerDrones.Add(drone);
    }

    private void AttachMinerDrone(MinerDrone drone)
    {
        _AttachedMinerDrones.Add(drone);
        PlaceMinerDrone(drone, _AttachedMinerDrones.Count - 1);
    }

    private void PlaceMinerDrone(MinerDrone drone, int index)
    {
        Vector3 dronePos = transform.position -(Vector3.up) - (Vector3.forward * 0.5f);
        dronePos += (Vector3.up + new Vector3(0.0f, index, 0.0f));
        drone.transform.position = dronePos;
        drone.transform.rotation = new Quaternion(-45.0f, 0.0f, 0.0f, 45.0f);
    }

    public bool CheckIfSlotsAvailable()
    {
        return _SlotsAvailable;
    }

    public void UpdateSlotsUsed()
    {
        _CurrentSlotsUsed += 1;
        if(_CurrentSlotsUsed >= _AmountOfSlots)
        {
            _SlotsAvailable = false;
        }
    }

    private void MineCrystal()
    {
        int crystalsMined = _CurrentSlotsUsed;
        _Player.AddCrystals(crystalsMined);
    }
}
