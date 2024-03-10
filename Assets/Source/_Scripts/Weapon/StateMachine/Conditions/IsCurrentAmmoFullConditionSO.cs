using UnityEngine;

[CreateAssetMenu(
	fileName = "SO_IsCurrentAmmoFullCondition",
	menuName = "Scriptable Objects/State Machine/Conditions/Weapon/SO_IsCurrentAmmoFullCondition"
)]
public class IsCurrentAmmoFullConditionSO : StateConditionSO
{
	protected override Condition CreateCondition() => new IsCurrentAmmoFullCondition();
}

public class IsCurrentAmmoFullCondition : Condition
{
	protected new IsCurrentAmmoFullConditionSO OriginSO => (IsCurrentAmmoFullConditionSO)base.OriginSO;
	private Weapon _weapon;

	public override void Awake(StateMachine stateMachine)
	{
		_weapon = stateMachine.GetComponent<Weapon>();
	}

	protected override bool Statement()
	{
		var weaponData = _weapon.WeaponData;
		return weaponData.currentAmmo == weaponData.magazineSize;
	}

	public override void OnStateEnter()
	{
	}

	public override void OnStateExit()
	{
	}
}
