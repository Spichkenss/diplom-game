using UnityEngine;

[CreateAssetMenu(
    fileName = "SO_ControlRigBuilderAction",
    menuName = "Scriptable Objects/State Machine/Actions/Weapon/SO_ControlRigBuilderAction"
)]
public class ControlRigBuilderActionSO : StateActionSO
{
    public StateAction.SpecificMoment moment;
    public bool setTo;
    
    protected override StateAction CreateAction()
    {
        return new ControlRigBuilderAction();
    }
}

public class ControlRigBuilderAction : StateAction
{
    private Weapon _weapon;
    protected new ControlRigBuilderActionSO OriginSO => (ControlRigBuilderActionSO)base.OriginSO;

    public override void Awake(StateMachine stateMachine)
    {
        _weapon = stateMachine.GetComponent<Weapon>();
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
        _weapon.RigBuilder.enabled = OriginSO.setTo;
    }
}