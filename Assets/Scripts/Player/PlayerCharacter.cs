using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCharacter : BasicCharacter
{
    [SerializeField]
    private InputActionAsset _InputAsset;

    [SerializeField]
    private InputActionReference _MovementAction;

    private InputAction _InteractAction;

    [SerializeField]
    private int _AmountOfCrystals;

    public delegate void CrystalChanged(int crystal);

    public event CrystalChanged OnCrystalChange;

    protected InteractBehavior _InteractBehavior;

    protected override void Awake()
    {
        _InteractBehavior = GetComponent<InteractBehavior>();
        base.Awake();

        if (_InputAsset == null) return;

        //example of searching for the bindings in code
        _InteractAction = _InputAsset.FindActionMap("Gameplay").FindAction("Interact");
    }

    private void OnEnable()
    {
        if(_InputAsset == null) return;

        _InputAsset.Enable();
    }

    private void OnDisable()
    {
        if (_InputAsset == null) return;

        _InputAsset.Disable();
    }

    private void Update()
    {
        HandleMovementInput();
        HandleInteractInput();
    }

    void HandleMovementInput()
    {
        if (_MovementBehavior == null ||
           _MovementAction == null)
            return;

        //movement
        float movementInput = _MovementAction.action.ReadValue<float>();

        Vector3 movement = movementInput * Vector3.right;

        _MovementBehavior.DesiredMovementDirection = movement;
    }

    private void HandleInteractInput()
    {
        if (_InteractBehavior == null ||
           _InteractAction == null)
            return;

        if (_InteractAction.IsPressed())
            _InteractBehavior.Interact();
    }

    public int Crystals { get { return _AmountOfCrystals; } }

    public void AddCrystals(int amount)
    {
        _AmountOfCrystals += amount;
        OnCrystalChange?.Invoke(_AmountOfCrystals);
    }

    public bool ConsumeCrystal(int cost)
    {
        if(_AmountOfCrystals >= cost)
        {
            _AmountOfCrystals -= cost;
            OnCrystalChange?.Invoke(_AmountOfCrystals);
            return true;
        }
        return false;
    }
}
