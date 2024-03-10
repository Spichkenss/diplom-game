using UnityEngine;


[CreateAssetMenu(
	fileName = "SO_IsCurrentAmmoLeftCondition",
	menuName = "Scriptable Objects/State Machine/Conditions/Weapon/SO_IsCurrentAmmoLeftCondition"
)]
public class IsCurrentAmmoLeftConditionSO : StateConditionSO
{
	protected override Condition CreateCondition() => new IsCurrentAmmoLeftCondition();
}

public class IsCurrentAmmoLeftCondition : Condition
{
	protected new IsCurrentAmmoLeftConditionSO OriginSO => (IsCurrentAmmoLeftConditionSO)base.OriginSO;
	private Weapon _weapon;

	public override void Awake(StateMachine stateMachine)
	{
		_weapon = stateMachine.GetComponent<Weapon>();
	}

	protected override bool Statement()
	{
		return _weapon.WeaponData.currentAmmo > 0;
	}

	public override void OnStateEnter()
	{
	}

	public override void OnStateExit()
	{
	}
}
