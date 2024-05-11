using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "SO_InputReader", menuName = "Scriptable Objects/Input/SO_InputReader")]
public class InputReader : ScriptableObject, InputActions.IPlayerActions
{
    private InputActions _inputActions;

    private void OnEnable()
    {
        if (_inputActions == null)
        {
            _inputActions = new InputActions();
            _inputActions.Player.SetCallbacks(this);
        }

        EnableGameplayInput();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        MoveEvent.Invoke(context.ReadValue<Vector2>());
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        LookEvent.Invoke(context.ReadValue<Vector2>());
    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        ShootEvent.Invoke(context.ReadValueAsButton());
    }

    public void OnReload(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        ReloadEvent.Invoke();
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        InteractEvent.Invoke();
    }

    private void DisablePlayerInput()
    {
        _inputActions.Player.Disable();    
    }

    private void EnableGameplayInput()
    {
        _inputActions.Player.Enable();
    }
    
    public event UnityAction<Vector2> MoveEvent = delegate { };
    public event UnityAction<Vector2> LookEvent = delegate { };
    public event UnityAction<bool> ShootEvent = delegate { };
    public event UnityAction ReloadEvent = delegate { };
    public event UnityAction InteractEvent = delegate { };
}