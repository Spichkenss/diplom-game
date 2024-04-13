using UnityEngine;

[CreateAssetMenu(
    fileName = "SO_ControlRigBuilderAction",
    menuName = "Scriptable Objects/State Machine/Actions/Common/SO_ControlRigBuilderAction"
)]
public class ControlRigBuilderActionSO : StateActionSO
{
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
    }

    public override void OnStateEnter()
    {
        _weapon.RigBuilder.enabled = false;
    }

    public override void OnStateExit()
    {
        _weapon.RigBuilder.enabled = true;
    }
}