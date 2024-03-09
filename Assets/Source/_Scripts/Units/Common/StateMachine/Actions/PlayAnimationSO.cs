using UnityEngine;

[CreateAssetMenu(fileName = "SO_PlayAnimation", menuName = "Scriptable Objects/State Machine/Actions/SO_PlayAnimation")]
public class PlayAnimationSO : StateActionSO
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

	protected override StateAction CreateAction() => new PlayAnimation(Animator.StringToHash(animationHash));
}

public class PlayAnimation : StateAction
{
	protected new PlayAnimationSO OriginSO => (PlayAnimationSO)base.OriginSO;
	private Animator _animator;
	private int _animationHash;

	public PlayAnimation(int animationHash)
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
			case PlayAnimationSO.ParameterType.Bool:
				_animator.SetBool(_animationHash, OriginSO.boolValue);
				break;
			case PlayAnimationSO.ParameterType.Int:
				_animator.SetInteger(_animationHash, OriginSO.intValue);
				break;
			case PlayAnimationSO.ParameterType.Float:
				_animator.SetFloat(_animationHash, OriginSO.floatValue);
				break;
			case PlayAnimationSO.ParameterType.Trigger:
				_animator.SetTrigger(_animationHash);
				break;
		}
	}
}
