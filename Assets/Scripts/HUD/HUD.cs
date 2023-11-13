using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HUD : MonoBehaviour
{
    private UIDocument _AttachedDocument = null;
    private VisualElement _Root = null;

    private Label _NumberField = null;

    // Start is called before the first frame update
    void Start()
    {
        _AttachedDocument = GetComponent<UIDocument>();
        if( _AttachedDocument != null)
        {
            _Root = _AttachedDocument.rootVisualElement;
        }

        if(_Root != null)
        {
            _NumberField = _Root.Q<Label>();

            PlayerCharacter player = FindAnyObjectByType<PlayerCharacter>();
            if( player != null )
            {
                UpdateCrystals(player.Crystals);

                player.OnCrystalChange += UpdateCrystals;
            }
        }
    }

    void UpdateCrystals(int crystals)
    {
        _NumberField.text = crystals.ToString();
    }
}
