using UnityEngine;

[CreateAssetMenu(
    fileName = "SO_IsShootingHoldingCondition",
    menuName = "Scriptable Objects/State Machine/Conditions/Weapon/SO_IsShootingHoldingCondition"
)]
public class IsShootingPressedConditionSO : StateConditionSO
{
    protected override Condition CreateCondition()
    {
        return new IsShootingPressedCondition();
    }
}

public class IsShootingPressedCondition : Condition
{
    private Weapon _weapon;
    protected new IsShootingPressedConditionSO OriginSO => (IsShootingPressedConditionSO)base.OriginSO;

    public override void Awake(StateMachine stateMachine)
    {
        _weapon = stateMachine.GetComponent<Weapon>();
    }

    protected override bool Statement()
    {
        return _weapon.IsShootingHolding;
    }

    public override void OnStateEnter()
    {
    }

    public override void OnStateExit()
    {
    }
}