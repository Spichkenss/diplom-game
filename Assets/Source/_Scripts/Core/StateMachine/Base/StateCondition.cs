/// <summary>
///     Class that represents a conditional statement.
/// </summary>
public abstract class Condition : IStateComponent
{
    private bool _cachedStatement;
    private bool _isCached;
    internal StateConditionSO _originSO;

    /// <summary>
    ///     Use this property to access shared data from the <see cref="StateConditionSO" /> that corresponds to this
    ///     <see cref="Condition" />
    /// </summary>
    protected StateConditionSO OriginSO => _originSO;

    public virtual void OnStateEnter()
    {
    }

    public virtual void OnStateExit()
    {
    }

    /// <summary>
    ///     Specify the statement to evaluate.
    /// </summary>
    /// <returns></returns>
    protected abstract bool Statement();

    /// <summary>
    ///     Wrap the <see cref="Statement" /> so it can be cached.
    /// </summary>
    internal bool GetStatement()
    {
        if (!_isCached)
        {
            _isCached = true;
            _cachedStatement = Statement();
        }

        return _cachedStatement;
    }

    internal void ClearStatementCache()
    {
        _isCached = false;
    }

    /// <summary>
    ///     Awake is called when creating a new instance. Use this method to cache the components needed for the condition.
    /// </summary>
    /// <param name="stateMachine">The <see cref="StateMachine" /> this instance belongs to.</param>
    public virtual void Awake(StateMachine stateMachine)
    {
    }
}

/// <summary>
///     Struct containing a Condition and its expected result.
/// </summary>
public readonly struct StateCondition
{
    internal readonly StateMachine StateMachine;
    internal readonly Condition Condition;
    internal readonly bool ExpectedResult;

    public StateCondition(StateMachine stateMachine, Condition condition, bool expectedResult)
    {
        StateMachine = stateMachine;
        Condition = condition;
        ExpectedResult = expectedResult;
    }

    public bool IsMet()
    {
        var statement = Condition.GetStatement();
        var isMet = statement == ExpectedResult;

#if UNITY_EDITOR
        StateMachine._debugger.TransitionConditionResult(Condition._originSO.name, statement, isMet);
#endif
        return isMet;
    }
}