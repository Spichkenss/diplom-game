using UnityEngine;

[CreateAssetMenu(
    fileName = "SO_ApplyGravityAction",
    menuName = "Scriptable Objects/State Machine/Actions/Player/SO_ApplyGravityAction"
)]
public class ApplyGravityActionSO : StateActionSO
{
    public float verticalPull = -5f;

    protected override StateAction CreateAction()
    {
        return new ApplyGravityAction();
    }
}

public class ApplyGravityAction : StateAction
{
    private MovementHandler _movementHandler;
    protected new ApplyGravityActionSO OriginSO => (ApplyGravityActionSO)base.OriginSO;

    public override void Awake(StateMachine stateMachine)
    {
        _movementHandler = stateMachine.GetComponent<MovementHandler>();
    }

    public override void OnUpdate()
    {
        _movementHandler.MovementVector.y = OriginSO.verticalPull;
    }
}
