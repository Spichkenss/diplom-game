using UnityEngine;

[CreateAssetMenu(fileName = "SO_ApplyMovementVectorAction", menuName = "Scriptable Objects/State Machine/Actions/SO_ApplyMovementVectorAction")]
public class ApplyMovementVectorActionSO : StateActionSO
{
	protected override StateAction CreateAction() => new ApplyMovementVectorAction();
}

public class ApplyMovementVectorAction : StateAction
{
	protected new ApplyMovementVectorActionSO OriginSO => (ApplyMovementVectorActionSO)base.OriginSO;
	private MovementHandler _movementHandler;
	private CharacterController _characterController;

	public override void Awake(StateMachine stateMachine)
	{
		_movementHandler = stateMachine.GetComponent<MovementHandler>();
		_characterController = stateMachine.GetComponent<CharacterController>();
	}
	
	public override void OnUpdate()
	{
		var movementVector = _movementHandler.MovementVector;
		_characterController.Move(movementVector * Time.deltaTime);
		_movementHandler.MovementVector = _characterController.velocity;
	}
}
