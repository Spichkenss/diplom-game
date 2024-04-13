using System.Collections.Generic;

public class State
{
    internal StateAction[] Actions;
    internal StateSO OriginSo;
    internal StateMachine StateMachine;
    internal StateTransition[] Transitions;

    internal State()
    {
    }

    public State(
        StateSO originSO,
        StateMachine stateMachine,
        StateTransition[] transitions,
        StateAction[] actions)
    {
        OriginSo = originSO;
        StateMachine = stateMachine;
        Transitions = transitions;
        Actions = actions;
    }

    public void OnStateEnter()
    {
        OnStateEnter(Transitions);
        OnStateEnter(Actions);

        void OnStateEnter(IEnumerable<IStateComponent> components)
        {
            foreach (var component in components)
                component.OnStateEnter();
        }
    }

    public void OnUpdate()
    {
        foreach (var action in Actions)
            action.OnUpdate();
    }

    public void OnStateExit()
    {
        void OnStateExit(IEnumerable<IStateComponent> comps)
        {
            foreach (var t in comps)
                t.OnStateExit();
        }

        OnStateExit(Transitions);
        OnStateExit(Actions);
    }

    public bool TryGetTransition(out State state)
    {
        state = null;

        foreach (var transition in Transitions)
            if (transition.TryGetTransition(out state))
                break;

        foreach (var transition in Transitions)
            transition.ClearConditionsCache();

        return state != null;
    }
}