using UnityEngine;

[CreateAssetMenu(
	fileName = "SO_PerformShotAction",
	menuName = "Scriptable Objects/State Machine/Actions/Weapon/SO_PerformShotAction"
)]
public class PerformShotActionSO : StateActionSO
{
	protected override StateAction CreateAction() => new PerformShotAction();
}

public class PerformShotAction : StateAction
{
	protected new PerformShotActionSO OriginSO => (PerformShotActionSO)base.OriginSO;
	private Weapon _weapon;

	public override void Awake(StateMachine stateMachine)
	{
		_weapon = stateMachine.GetComponent<Weapon>();
	}

	public override void OnUpdate()
	{
		if (Time.time < _weapon.FireCooldown || _weapon.WeaponData.currentAmmo <= 0) return;
		_weapon.Shoot();
		DecreaseCurrentAmmo(1);
		UpdateCooldown();
	}

	public override void OnStateEnter()
	{
	}

	public override void OnStateExit()
	{
	}

	private void DecreaseCurrentAmmo(int amount)
	{
		_weapon.WeaponData.currentAmmo -= amount;
	}

	private void UpdateCooldown()
	{
		_weapon.FireCooldown = Time.time + 1f / _weapon.WeaponData.fireRate;
	}
}
