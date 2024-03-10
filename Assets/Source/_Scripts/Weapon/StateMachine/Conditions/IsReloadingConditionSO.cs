using UnityEngine;


[CreateAssetMenu(
	fileName = "SO_IsReloadingCondition",
 	menuName = "Scriptable Objects/State Machine/Conditions/Weapon/SO_IsReloadingCondition"
	)]
public class IsReloadingConditionSO : StateConditionSO
{
	protected override Condition CreateCondition() => new IsReloadingCondition();
}

public class IsReloadingCondition : Condition
{
	protected new IsReloadingConditionSO OriginSO => (IsReloadingConditionSO)base.OriginSO;
	private Weapon _weapon;

	public override void Awake(StateMachine stateMachine)
	{
		_weapon = stateMachine.GetComponent<Weapon>();
	}

	protected override bool Statement()
	{
		return _weapon.WeaponData.isReloading;
	}

	public override void OnStateEnter()
	{
	}

	public override void OnStateExit()
	{
	}
}
