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
        _Cost = 200;
    }

    override public void Interact()
    {
        if(_Player.ConsumeCrystal(_Cost))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
