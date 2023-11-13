using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BasicUpgrade : BasicInteractable
{
    protected int _UpgradeLevel = 1;
    private TextMeshProUGUI _UpgradeAmount = null;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        _Cost = 15;
        _UpgradeAmount = GetComponentInChildren<TextMeshProUGUI>();
        _UpgradeAmount.text = _Cost.ToString();
    }

    protected override void InteractEffect()
    {
        _UpgradeLevel += 1;
        _Cost += 5*_UpgradeLevel;
        _UpgradeAmount.text = _Cost.ToString();
    }
}
