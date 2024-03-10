using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "SO_InputReader", menuName = "Scriptable Objects/Input/SO_InputReader")]
public class InputReader : ScriptableObject, InputActions.IPlayerActions
{
    public event UnityAction<Vector2> MoveEvent = delegate { };
    public event UnityAction<Vector2> LookEvent = delegate { };
    public event UnityAction<bool> ShootEvent = delegate { };
    public event UnityAction ReloadEvent = delegate { };
    public event UnityAction InteractEvent = delegate { };

    private InputActions _inputActions;

    private void OnEnable()
    {
        if (_inputActions == null)
        {
            _inputActions = new InputActions();
            _inputActions.Player.SetCallbacks(this);
        }

        _inputActions.Player.Enable();
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
}
