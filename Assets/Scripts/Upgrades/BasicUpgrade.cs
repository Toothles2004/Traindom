using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class BasicUpgrade : BasicInteractable
{
    protected int _UpgradeLevel = 1;
    private TextMeshProUGUI _UpgradeAmount = null;
    private ParticleSystem _Particle;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        _UpgradeAmount = GetComponentInChildren<TextMeshProUGUI>();
        _UpgradeAmount.text = _Cost.ToString();
        _Particle = GetComponentInChildren<ParticleSystem>();
    }

    protected override void InteractEffect()
    {
        _UpgradeLevel += 1;
        _Cost += 5*_UpgradeLevel;
        _UpgradeAmount.text = _Cost.ToString();
        _Particle.Play();
    }
}
