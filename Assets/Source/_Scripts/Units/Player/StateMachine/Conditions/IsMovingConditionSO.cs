using UnityEngine;

[CreateAssetMenu(
    fileName = "SO_IsMovingCondition",
    menuName = "Scriptable Objects/State Machine/Conditions/Player/SO_IsMovingCondition"
)]
public class IsMovingConditionSO : StateConditionSO
{
    public float treshold = 0.02f;

    protected override Condition CreateCondition()
    {
        return new IsMovingCondition();
    }
}

public class IsMovingCondition : Condition
{
    private MovementHandler _movementHandler;
    protected new IsMovingConditionSO OriginSO => (IsMovingConditionSO)base.OriginSO;

    public override void Awake(StateMachine stateMachine)
    {
        _movementHandler = stateMachine.GetComponent<MovementHandler>();
    }

    protected override bool Statement()
    {
        Vector3 movementInput = _movementHandler.InputVector;
        return movementInput.magnitude > OriginSO.treshold;
    }

    public override void OnStateEnter()
    {
    }

    public override void OnStateExit()
    {
    }
}
