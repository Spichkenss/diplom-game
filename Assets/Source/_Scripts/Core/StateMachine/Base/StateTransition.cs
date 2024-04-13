public class StateTransition : IStateComponent
{
    private StateCondition[] _conditions;
    private int[] _resultGroups;
    private bool[] _results;
    private State _targetState;

    internal StateTransition()
    {
    }

    public StateTransition(State targetState, StateCondition[] conditions, int[] resultGroups = null)
    {
        Init(targetState, conditions, resultGroups);
    }

    public void OnStateEnter()
    {
        for (var i = 0; i < _conditions.Length; i++)
            _conditions[i].Condition.OnStateEnter();
    }

    public void OnStateExit()
    {
        for (var i = 0; i < _conditions.Length; i++)
            _conditions[i].Condition.OnStateExit();
    }

    internal void Init(State targetState, StateCondition[] conditions, int[] resultGroups = null)
    {
        _targetState = targetState;
        _conditions = conditions;
        _resultGroups = resultGroups != null && resultGroups.Length > 0 ? resultGroups : new int[1];
        _results = new bool[_resultGroups.Length];
    }

    /// <summary>
    ///     Checks wether the conditions to transition to the target state are met.
    /// </summary>
    /// <param name="state">Returns the state to transition to. Null if the conditions aren't met.</param>
    /// <returns>True if the conditions are met.</returns>
    public bool TryGetTransition(out State state)
    {
        state = ShouldTransition() ? _targetState : null;
        return state != null;
    }

    private bool ShouldTransition()
    {
#if UNITY_EDITOR
        _targetState.StateMachine._debugger.TransitionEvaluationBegin(_targetState.OriginSo.name);
#endif

        var count = _resultGroups.Length;
        for (int i = 0, idx = 0; i < count && idx < _conditions.Length; i++)
        for (var j = 0; j < _resultGroups[i]; j++, idx++)
            _results[i] = j == 0 ? _conditions[idx].IsMet() : _results[i] && _conditions[idx].IsMet();

        var ret = false;
        for (var i = 0; i < count && !ret; i++)
            ret = ret || _results[i];

#if UNITY_EDITOR
        _targetState.StateMachine._debugger.TransitionEvaluationEnd(ret, _targetState.Actions);
#endif

        return ret;
    }

    internal void ClearConditionsCache()
    {
        for (var i = 0; i < _conditions.Length; i++)
            _conditions[i].Condition.ClearStatementCache();
    }
}