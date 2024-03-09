using UnityEngine;


[CreateAssetMenu(fileName = "SO_SetMovementVectorAction", menuName = "Scriptable Objects/State Machine/Actions/SO_SetMovementVectorAction")]
public class SetMovementVectorActionSO : StateActionSO<SetMovementVectorAction>
{
    public float moveSpeed = 10f;
}

public class SetMovementVectorAction : StateAction
{
    protected new SetMovementVectorActionSO OriginSO => (SetMovementVectorActionSO)base.OriginSO;
    private MovementHandler _movementHandler;

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
