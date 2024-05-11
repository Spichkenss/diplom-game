using UnityEngine;
using UnityEngine.Animations.Rigging;

[CreateAssetMenu(
    fileName = "SO_ControlRigBuilderByPlayerAction",
    menuName = "Scriptable Objects/State Machine/Actions/Player/SO_ControlRigBuilderByPlayerAction"
)]
public class ControlRigBuilderByPlayerActionSO : StateActionSO
{
    public StateAction.SpecificMoment moment;
    public bool setTo;
    
    protected override StateAction CreateAction()
    {
        return new ControlRigBuilderByPlayerAction();
    }
}

public class ControlRigBuilderByPlayerAction : StateAction
{
    private RigBuilder _rigBuilder;
    protected new ControlRigBuilderByPlayerActionSO OriginSO => (ControlRigBuilderByPlayerActionSO)base.OriginSO;

    public override void Awake(StateMachine stateMachine)
    {
        _rigBuilder = stateMachine.GetComponent<RigBuilder>();
    }

    public override void OnUpdate()
    {
        if (OriginSO.moment == SpecificMoment.OnUpdate) SetRigBuilderState();
    }

    public override void OnStateEnter()
    {
        if (OriginSO.moment == SpecificMoment.OnStateEnter) SetRigBuilderState();
    }

    public override void OnStateExit()
    {
        if (OriginSO.moment == SpecificMoment.OnStateExit) SetRigBuilderState();
    }

    private void SetRigBuilderState()
    {
        _rigBuilder.enabled = OriginSO.setTo;
    }
}