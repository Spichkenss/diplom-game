using UnityEngine;

[CreateAssetMenu(
	fileName = "SO_ReloadAction",
	menuName = "Scriptable Objects/State Machine/Actions/Weapon/SO_ReloadAction"
)]
public class ReloadActionSO : StateActionSO
{
	protected override StateAction CreateAction() => new ReloadAction();
}

public class ReloadAction : StateAction
{
	protected new ReloadActionSO OriginSO => (ReloadActionSO)base.OriginSO;
	private Weapon _weapon;

	public override void Awake(StateMachine stateMachine)
	{
		_weapon = stateMachine.GetComponent<Weapon>();
	}

	public override void OnUpdate()
	{
	}

	public override void OnStateEnter()
	{
		_weapon.StartReloading();
	}

	public override void OnStateExit()
	{
	}
}
