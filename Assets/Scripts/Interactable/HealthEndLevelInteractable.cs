using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthEndLevelInteractable : Health
{
    protected override void Start()
    {
        _MaxHealth = 100;
        _CurrentHealth = _MaxHealth;
    }

    // If the enemies destroy the cargo, reload the level
    protected override void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
