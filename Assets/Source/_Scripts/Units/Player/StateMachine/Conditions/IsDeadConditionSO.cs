using UnityEngine;

[CreateAssetMenu(fileName = "SO_IsDeadCondition", menuName = "Scriptable Objects/State Machine/Conditions/Player/SO_IsDeadCondition")]
public class IsDeadConditionSO : StateConditionSO
{
	protected override Condition CreateCondition() => new IsDeadCondition();
}

public class IsDeadCondition : Condition
{
	protected new IsDeadConditionSO OriginSO => (IsDeadConditionSO)base.OriginSO;
	private Health _health;

	public override void Awake(StateMachine stateMachine)
	{
		_health = stateMachine.GetComponent<Health>();
	}
	
	protected override bool Statement()
	{
		return _health.currentValue <= 0;
	}
	
	public override void OnStateEnter()
	{
	}
	
	public override void OnStateExit()
	{
	}
}
