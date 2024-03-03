using UnityEngine;

[CreateAssetMenu(fileName = "SO_ApplyGravityAction", menuName = "Scriptable Objects/State Machine/Actions/SO_ApplyGravityAction")]
public class ApplyGravityActionSO : StateActionSO<ApplyGravityAction>
{
	public float verticalPull = -5f;
}

public class ApplyGravityAction : StateAction
{
	protected new ApplyGravityActionSO OriginSO => (ApplyGravityActionSO)base.OriginSO;
	private MovementHandler _movementHandler;

	public override void Awake(StateMachine stateMachine)
	{
		_movementHandler = stateMachine.GetComponent<MovementHandler>();
	}
	
	public override void OnUpdate()
	{
		_movementHandler.MovementVector.y = OriginSO.verticalPull;
	}
}
