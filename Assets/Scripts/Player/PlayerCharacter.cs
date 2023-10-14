using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCharacter : BasicCharacter
{
    [SerializeField]
    private InputActionAsset _inputAsset;

    [SerializeField]
    private InputActionReference _movementAction;

    private InputAction _interactAction;

    protected override void Awake()
    {
        base.Awake();

        if (_inputAsset == null) return;

        //example of searching for the bindings in code
        _interactAction = _inputAsset.FindActionMap("Gameplay").FindAction("Interact");
    }

    private void OnEnable()
    {
        if(_inputAsset == null) return;

        _inputAsset.Enable();
    }

    private void OnDisable()
    {
        if (_inputAsset == null) return;

        _inputAsset.Disable();
    }

    private void Update()
    {
        HandleMovementInput();
        HandleInteractInput();
    }

    void HandleMovementInput()
    {
        if (_movementBehavior == null ||
           _movementAction == null)
            return;

        //movement
        float movementInput = _movementAction.action.ReadValue<float>();

        Vector3 movement = movementInput * Vector3.right;

        _movementBehavior.DesiredMovementDirection = movement;
    }

    private void HandleInteractInput()
    {
        if (_interactBehavior == null ||
           _interactAction == null)
            return;

        if (_interactAction.IsPressed())
            _interactBehavior.Interact();
    }
}
