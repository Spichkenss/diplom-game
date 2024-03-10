using UnityEngine;

public class FollowByCursor : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;

    private Vector2 _mousePosition;
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void OnEnable()
    {
        _inputReader.LookEvent += OnLook;
    }

    private void OnDisable()
    {
        _inputReader.LookEvent -= OnLook;
    }

    private void Update()
    {
        MoveAimTargetToMousePosition();
    }

    private void MoveAimTargetToMousePosition()
    {
        // Переводим координаты курсора в мировые координаты
        Vector3 mouseWorldPosition = GetMouseWorldPosition();
        mouseWorldPosition.y = 0.5f;
        transform.position = mouseWorldPosition;
    }

    private void OnLook(Vector2 mousePosition)
    {
        _mousePosition = mousePosition;
    }

    private Vector3 GetMouseWorldPosition()
    {
        return _camera.ScreenToWorldPoint(new Vector3(
            _mousePosition.x,
            _mousePosition.y,
            _camera.transform.position.y
        ));
    }
}
