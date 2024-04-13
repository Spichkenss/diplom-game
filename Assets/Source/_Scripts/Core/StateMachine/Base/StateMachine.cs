using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [Tooltip("Set the initial state of this StateMachine")] [SerializeField]
    private TransitionTableSO _transitionTableSO;

#if UNITY_EDITOR
    [Space] [SerializeField] internal StateMachineDebugger _debugger;
#endif

    private readonly Dictionary<Type, Component> _cachedComponents = new();
    internal State CurrentState;

    private void Awake()
    {
        CurrentState = _transitionTableSO.GetInitialState(this);
#if UNITY_EDITOR
        _debugger.Awake(this);
#endif
    }

    private void Start()
    {
        CurrentState.OnStateEnter();
    }

    private void Update()
    {
        if (CurrentState.TryGetTransition(out var transitionState))
            Transition(transitionState);

        CurrentState.OnUpdate();
    }

    public new bool TryGetComponent<T>(out T component) where T : Component
    {
        var type = typeof(T);
        if (!_cachedComponents.TryGetValue(type, out var value))
        {
            if (base.TryGetComponent(out component))
                _cachedComponents.Add(type, component);

            return component != null;
        }

        component = (T)value;
        return true;
    }

    public T GetOrAddComponent<T>() where T : Component
    {
        if (!TryGetComponent<T>(out var component))
        {
            component = gameObject.AddComponent<T>();
            _cachedComponents.Add(typeof(T), component);
        }

        return component;
    }

    public new T GetComponent<T>() where T : Component
    {
        return TryGetComponent(out T component)
            ? component
            : throw new InvalidOperationException($"{typeof(T).Name} not found in {name}.");
    }

    private void Transition(State transitionState)
    {
        CurrentState.OnStateExit();
        CurrentState = transitionState;
        CurrentState.OnStateEnter();
    }

#if UNITY_EDITOR
    private void OnEnable()
    {
        AssemblyReloadEvents.afterAssemblyReload += OnAfterAssemblyReload;
    }

    private void OnAfterAssemblyReload()
    {
        CurrentState = _transitionTableSO.GetInitialState(this);
        _debugger.Awake(this);
    }

    private void OnDisable()
    {
        AssemblyReloadEvents.afterAssemblyReload -= OnAfterAssemblyReload;
    }
#endif
}