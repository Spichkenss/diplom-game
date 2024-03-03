using UnityEngine;

[CreateAssetMenu(fileName = "SO_PlayWalkAnimation", menuName = "Scriptable Objects/State Machine/Actions/SO_PlayWalkAnimation")]
public class PlayWalkAnimationSO : StateActionSO
{
	protected override StateAction CreateAction() => new PlayWalkAnimation();
}

public class PlayWalkAnimation : StateAction
{
	protected new PlayWalkAnimationSO OriginSO => (PlayWalkAnimationSO)base.OriginSO;

	public override void Awake(StateMachine stateMachine)
	{
	}
	
	public override void OnUpdate()
	{
	}
	
	public override void OnStateEnter()
	{
	}
	
	public override void OnStateExit()
	{
	}
}
