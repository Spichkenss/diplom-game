using UnityEngine;

[CreateAssetMenu(
    fileName = "SO_HandleRotationAction",
    menuName = "Scriptable Objects/State Machine/Actions/Player/SO_HandleRotationAction"
)]
public class HandleRotationActionSO : StateActionSO
{
    public float rotationSpeed = 20f;

    protected override StateAction CreateAction()
    {
        return new HandleRotationAction();
    }
}

public class HandleRotationAction : StateAction
{
    private Camera _camera;
    private RotationHandler _rotationHandler;
    private Transform _transform;
    protected new HandleRotationActionSO OriginSO => (HandleRotationActionSO)base.OriginSO;

    public override void Awake(StateMachine stateMachine)
    {
        _transform = stateMachine.GetComponent<Transform>();
        _rotationHandler = stateMachine.GetComponent<RotationHandler>();
        _camera = Camera.main;
    }

    public override void OnUpdate()
    {
        // Переводим координаты курсора в мировые координаты
        var mouseWorldPosition = GetMouseWorldPosition();

        // Находим направление курсора от игрока
        var direction = mouseWorldPosition - _transform.position;
        direction.y = 0; // Игнорируем изменения высоты

        // Поворачиваем игрока в сторону курсора
        if (direction == Vector3.zero) return;

        var lookRotation = Quaternion.LookRotation(direction);
        _transform.rotation =
            Quaternion.Lerp(_transform.rotation, lookRotation, Time.deltaTime * OriginSO.rotationSpeed);

        Debug.DrawRay(_transform.position, _transform.forward * 100f, Color.red);
    }

    private Vector3 GetMouseWorldPosition()
    {
        var mousePosition = _rotationHandler.MousePosition;
        return Camera.main.ScreenToWorldPoint(new Vector3(
            mousePosition.x,
            mousePosition.y,
            _camera.transform.position.y
        ));
    }
}
