using UnityEngine;

[CreateAssetMenu(fileName = "SO_HandleRotationAction",
    menuName = "Scriptable Objects/State Machine/Actions/SO_HandleRotationAction")]
public class HandleRotationActionSO : StateActionSO<HandleRotationAction>
{
    public float rotationSpeed = 20f;
}

public class HandleRotationAction : StateAction
{
    protected new HandleRotationActionSO OriginSO => (HandleRotationActionSO)base.OriginSO;
    private Transform _transform;
    private RotationHandler _rotationHandler;

    public override void Awake(StateMachine stateMachine)
    {
        _transform = stateMachine.GetComponent<Transform>();
        _rotationHandler = stateMachine.GetComponent<RotationHandler>();
    }

    public override void OnUpdate()
    {
        // Переводим координаты курсора в мировые координаты
        Vector3 mouseWorldPosition = GetMouseWorldPosition();

        // Находим направление курсора от игрока
        Vector3 direction = mouseWorldPosition - _transform.position;
        direction.y = 0; // Игнорируем изменения высоты

        // Поворачиваем игрока в сторону курсора
        if (direction == Vector3.zero) return;

        Quaternion lookRotation = Quaternion.LookRotation(direction);
        _transform.rotation = Quaternion.Slerp(_transform.rotation, lookRotation, Time.deltaTime * OriginSO.rotationSpeed);
    }

    private Vector3 GetMouseWorldPosition()
    {
        var mousePosition = _rotationHandler.MousePosition;
        return Camera.main.ScreenToWorldPoint(new Vector3(
            mousePosition.x,
            mousePosition.y,
            Camera.main.transform.position.y
        ));
    }
}
