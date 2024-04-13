using UnityEngine;

[CreateAssetMenu(
    fileName = "SO_SetAnimationLayerWeightAction",
    menuName = "Scriptable Objects/State Machine/Actions/Common/SO_SetAnimationLayerWeightAction"
)]
public class SetAnimationLayerWeightActionSO : StateActionSO
{
    public string targetLayerName;
    public string baseLayerName;
    public float weight;

    protected override StateAction CreateAction()
    {
        return new SetAnimationLayerWeightAction();
    }
}

public class SetAnimationLayerWeightAction : StateAction
{
    private Animator _animator;
    private int _baseLayerIndex;
    private int _targetLayerIndex;
    private float _weight;
    protected new SetAnimationLayerWeightActionSO OriginSO => (SetAnimationLayerWeightActionSO)base.OriginSO;

    public override void Awake(StateMachine stateMachine)
    {
        _animator = stateMachine.GetComponentInParent<Animator>();
        _targetLayerIndex = _animator.GetLayerIndex(OriginSO.targetLayerName);
        _baseLayerIndex = _animator.GetLayerIndex(OriginSO.baseLayerName);
    }

    public override void OnUpdate()
    {
    }

    public override void OnStateEnter()
    {
        DisableAllLayersExcept(_targetLayerIndex);
    }

    public override void OnStateExit()
    {
        DisableAllLayersExcept(_baseLayerIndex);
    }

    private void DisableAllLayersExcept(int layerIndex)
    {
        if (layerIndex == -1) return;

        _animator.SetLayerWeight(layerIndex, 1f);

        for (var i = 0; i < _animator.layerCount; i++)
            if (i != layerIndex)
                _animator.SetLayerWeight(i, 0f);
    }
}
