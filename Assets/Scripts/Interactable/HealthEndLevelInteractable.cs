using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthEndLevelInteractable : Health
{
    protected override void Start()
    {
        _MaxHealth = 100;
    }
    protected override void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
