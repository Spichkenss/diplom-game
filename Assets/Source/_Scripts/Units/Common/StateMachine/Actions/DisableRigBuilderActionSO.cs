using UnityEngine;
using UnityEngine.Animations.Rigging;

[CreateAssetMenu(
	fileName = "SO_DisableRigBuilderAction",
	menuName = "Scriptable Objects/State Machine/Actions/Common/SO_DisableRigBuilderAction"
)]
public class DisableRigBuilderActionSO : StateActionSO
{
	protected override StateAction CreateAction() => new DisableRigBuilderAction();
}

public class DisableRigBuilderAction : StateAction
{
	protected new DisableRigBuilderActionSO OriginSO => (DisableRigBuilderActionSO)base.OriginSO;
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
		_weapon.RigBuilder.enabled = false;
	}

	public override void OnStateExit()
	{
		_weapon.RigBuilder.enabled = true;
	}
}
