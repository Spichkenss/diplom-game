using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New State", menuName = "Scriptable Objects/State Machine/State")]
public class StateSO : ScriptableObject
{
    [SerializeField] private StateActionSO[] _actions;

    /// <summary>
    ///     Will create a new state or return an existing one inside <paramref name="createdInstances" />.
    /// </summary>
    internal State GetState(StateMachine stateMachine,
        Dictionary<ScriptableObject, object> createdInstances)
    {
        if (createdInstances.TryGetValue(this, out var obj))
            return (State)obj;

        var state = new State();
        createdInstances.Add(this, state);

        state.OriginSo = this;
        state.StateMachine = stateMachine;
        state.Transitions = new StateTransition[0];
        state.Actions = GetActions(_actions, stateMachine, createdInstances);

        return state;
    }

    private static StateAction[] GetActions(StateActionSO[] scriptableActions,
        StateMachine stateMachine, Dictionary<ScriptableObject, object> createdInstances)
    {
        var count = scriptableActions.Length;
        var actions = new StateAction[count];
        for (var i = 0; i < count; i++)
            actions[i] = scriptableActions[i].GetAction(stateMachine, createdInstances);

        return actions;
    }
}