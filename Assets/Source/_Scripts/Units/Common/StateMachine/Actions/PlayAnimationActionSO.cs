using UnityEngine;

[CreateAssetMenu(
	fileName = "SO_PlayAnimationAction",
	menuName = "Scriptable Objects/State Machine/Actions/Common/SO_PlayAnimationAction"
)]
public class PlayAnimationActionSO : StateActionSO
{
	public enum ParameterType
	{
		Bool, Int, Float, Trigger,
	}

	public ParameterType parameterType;
	public StateAction.SpecificMoment moment = default;
	public string animationHash;

	public bool boolValue = default;
	public int intValue = default;
	public float floatValue = default;

	protected override StateAction CreateAction() => new PlayAnimationAction(Animator.StringToHash(animationHash));
}

public class PlayAnimationAction : StateAction
{
	protected new PlayAnimationActionSO OriginSO => (PlayAnimationActionSO)base.OriginSO;
	private Animator _animator;
	private int _animationHash;

	public PlayAnimationAction(int animationHash)
	{
		_animationHash = animationHash;
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
		if (OriginSO.moment == SpecificMoment.OnStateEnter)
		{
			SetParameter();
		}
	}

	public override void OnStateExit()
	{
		if (OriginSO.moment == SpecificMoment.OnStateExit)
		{
			SetParameter();
		}
	}

	private void SetParameter()
	{
		switch (OriginSO.parameterType)
		{
			case PlayAnimationActionSO.ParameterType.Bool:
				_animator.SetBool(_animationHash, OriginSO.boolValue);
				break;
			case PlayAnimationActionSO.ParameterType.Int:
				_animator.SetInteger(_animationHash, OriginSO.intValue);
				break;
			case PlayAnimationActionSO.ParameterType.Float:
				_animator.SetFloat(_animationHash, OriginSO.floatValue);
				break;
			case PlayAnimationActionSO.ParameterType.Trigger:
				_animator.SetTrigger(_animationHash);
				break;
		}
	}
}
