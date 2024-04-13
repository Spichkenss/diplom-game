using UnityEngine;

[CreateAssetMenu(
    fileName = "SO_SetMovementVectorAction",
    menuName = "Scriptable Objects/State Machine/Actions/Player/SO_SetMovementVectorAction"
)]
public class SetMovementVectorActionSO : StateActionSO
{
    public float moveSpeed = 10f;

    protected override StateAction CreateAction()
    {
        return new SetMovementVectorAction();
    }
}

public class SetMovementVectorAction : StateAction
{
    private MovementHandler _movementHandler;
    protected new SetMovementVectorActionSO OriginSO => (SetMovementVectorActionSO)base.OriginSO;

    public override void Awake(StateMachine stateMachine)
    {
        _movementHandler = stateMachine.GetComponent<MovementHandler>();
    }

    public override void OnUpdate()
    {
        _movementHandler.MovementVector.x = _movementHandler.InputVector.x * OriginSO.moveSpeed;
        _movementHandler.MovementVector.z = _movementHandler.InputVector.y * OriginSO.moveSpeed;
    }
}
