using UnityEngine;

[CreateAssetMenu(fileName = "SO_Play2DAnimationAction",
    menuName = "Scriptable Objects/State Machine/Actions/Player/SO_Play2DAnimationAction")]
public class Play2DAnimationActionSO : StateActionSO
{
    public string xAxisParamName;
    public string yAxisParamName;

    protected override StateAction CreateAction() => new Play2DAnimationAction(
        Animator.StringToHash(xAxisParamName),
        Animator.StringToHash(yAxisParamName)
    );
}

public class Play2DAnimationAction : StateAction
{
    protected new Play2DAnimationActionSO OriginSO => (Play2DAnimationActionSO)base.OriginSO;
    private readonly int _xAxisHash;
    private readonly int _yAxisHash;
    private Animator _animator;
    private MovementHandler _movementHandler;
    private Transform _playerTransform;

    public Play2DAnimationAction(int xAxisHash, int yAxisHash)
    {
        _xAxisHash = xAxisHash;
        _yAxisHash = yAxisHash;
    }
    
    public override void Awake(StateMachine stateMachine)
    {
        _animator = stateMachine.GetComponent<Animator>();
        _movementHandler = stateMachine.GetComponent<MovementHandler>();
        _playerTransform = stateMachine.transform;
    }
    
    public override void OnUpdate()
    {
        var moveVectorByPlayerDirection =
            Quaternion.Euler(0f, _playerTransform.eulerAngles.y, 0f) * _movementHandler.MovementVector;
        SetParameter(moveVectorByPlayerDirection.x, moveVectorByPlayerDirection.z);
    }

    public override void OnStateExit()
    {
        SetParameter(0f, 0f);
    }

    private void SetParameter(float xParam, float yParam)
    {
        _animator.SetFloat(_xAxisHash, xParam);
        _animator.SetFloat(_yAxisHash, yParam);
    }
}