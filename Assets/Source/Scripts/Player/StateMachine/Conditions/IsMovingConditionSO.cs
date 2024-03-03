using UnityEngine;

[CreateAssetMenu(fileName = "SO_IsMovingCondition", menuName = "Scriptable Objects/State Machine/Conditions/SO_IsMovingCondition")]
public class IsMovingConditionSO : StateConditionSO<IsMovingCondition>
{
	public float treshold = 0.02f;
}

public class IsMovingCondition : Condition
{
	protected new IsMovingConditionSO OriginSO => (IsMovingConditionSO)base.OriginSO;
	private MovementHandler _movementHandler;

	public override void Awake(StateMachine stateMachine)
	{
		_movementHandler = stateMachine.GetComponent<MovementHandler>();
	}
	
	protected override bool Statement()
	{
		Vector3 movementInput = _movementHandler.InputVector;
		return movementInput.magnitude > OriginSO.treshold;
	}
	
	public override void OnStateEnter()
	{
	}
	
	public override void OnStateExit()
	{
	}
}
