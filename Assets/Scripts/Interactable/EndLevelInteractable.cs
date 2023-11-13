using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using static UnityEditor.Experimental.GraphView.GraphView;

public class EndLevelInteractable : BasicInteractable
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        _UpgradeCost.text = _Cost.ToString();
    }

    override public void Interact()
    {
        // If the player has enough crystals load the next scene
        if(_Player.ConsumeCrystal(_Cost))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
    }
}
