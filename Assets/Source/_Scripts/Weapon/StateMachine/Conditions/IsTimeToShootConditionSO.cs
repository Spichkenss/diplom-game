using UnityEngine;


[CreateAssetMenu(
	fileName = "SO_IsTimeToShootCondition",
	menuName = "Scriptable Objects/State Machine/Conditions/Weapon/SO_IsTimeToShootCondition"
)]
public class IsTimeToShootConditionSO : StateConditionSO
{
	protected override Condition CreateCondition() => new IsTimeToShootCondition();
}

public class IsTimeToShootCondition : Condition
{
	protected new IsTimeToShootConditionSO OriginSO => (IsTimeToShootConditionSO)base.OriginSO;
	private Weapon _weapon;

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
