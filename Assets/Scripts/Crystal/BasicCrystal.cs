using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicCrystal : MonoBehaviour
{
    private bool _SlotsAvailable = true;
    private int _AmountOfSlots = 3;
    private int _CurrentSlotsUsed = 0;
    private float _MineTimer = 5.0f;

    private PlayerCharacter _Player = null;

    // Start is called before the first frame update
    private void Start()
    {
        _Player = FindAnyObjectByType<PlayerCharacter>();
        if( _Player != null )
        {
            InvokeRepeating("MineCrystal", _MineTimer, _MineTimer);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
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
