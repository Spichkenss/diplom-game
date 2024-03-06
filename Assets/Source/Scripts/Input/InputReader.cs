using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour, InputActions.IPlayerActions
{
    [SerializeField] private EventChannel<Vector2> _moveEventChannel;
    [SerializeField] private EventChannel<Vector2> _lookEventChannel;
    [SerializeField] private EventChannel<Empty> _shootEventChannel;
    [SerializeField] private EventChannel<Empty> _interactEventChannel;

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
        _moveEventChannel.Invoke(context.ReadValue<Vector2>());
    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        _shootEventChannel.Invoke(new Empty());
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        _lookEventChannel.Invoke(context.ReadValue<Vector2>());
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        _interactEventChannel.Invoke(new Empty());
    }
}
