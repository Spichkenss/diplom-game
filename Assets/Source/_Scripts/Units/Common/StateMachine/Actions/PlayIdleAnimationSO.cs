using UnityEngine;

[CreateAssetMenu(fileName = "SO_PlayIdleAnimation", menuName = "Scriptable Objects/State Machine/Actions/Common/SO_PlayIdleAnimation")]
public class PlayIdleAnimationSO : StateActionSO
{
	public string moveXParamName;
	public string moveZParamName;
	protected override StateAction CreateAction() => new PlayIdleAnimation(
		Animator.StringToHash(moveXParamName),
		Animator.StringToHash(moveZParamName)
		);
}

public class PlayIdleAnimation : StateAction
{
	protected new PlayIdleAnimationSO OriginSO => (PlayIdleAnimationSO)base.OriginSO;

	private Animator _animator;
	private int _moveXHash;
	private int _moveZHash;

	public PlayIdleAnimation(int moveXHash, int moveZHash)
	{
		_moveXHash = moveXHash;
		_moveZHash = moveZHash;
	}
	
	public override void Awake(StateMachine stateMachine)
	{
		_animator = stateMachine.GetComponent<Animator>();
	}
	
	public override void OnUpdate()
	{
	}
	
	public override void OnStateEnter()
	{
		_animator.SetFloat(_moveXHash, 0f);
		_animator.SetFloat(_moveZHash, 0f);
	}
	
	public override void OnStateExit()
	{
	}
}
