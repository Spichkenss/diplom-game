using UnityEngine;

[CreateAssetMenu(
    fileName = "SO_IsTimeToShootCondition",
    menuName = "Scriptable Objects/State Machine/Conditions/Weapon/SO_IsTimeToShootCondition"
)]
public class IsTimeToShootConditionSO : StateConditionSO
{
    protected override Condition CreateCondition()
    {
        return new IsTimeToShootCondition();
    }
}

public class IsTimeToShootCondition : Condition
{
    private Weapon _weapon;
    protected new IsTimeToShootConditionSO OriginSO => (IsTimeToShootConditionSO)base.OriginSO;

    public override void Awake(StateMachine stateMachine)
    {
        _weapon = stateMachine.GetComponent<Weapon>();
    }

    protected override bool Statement()
    {
        return Time.time >= _weapon.FireCooldown;
    }

    public override void OnStateEnter()
    {
    }

    public override void OnStateExit()
    {
    }
}