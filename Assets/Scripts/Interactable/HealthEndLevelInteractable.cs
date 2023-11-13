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
    protected override void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
