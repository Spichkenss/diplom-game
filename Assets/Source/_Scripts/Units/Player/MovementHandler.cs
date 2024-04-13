using System;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class MovementHandler : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [NonSerialized] public Vector2 InputVector;
    [NonSerialized] public Vector3 MovementVector;

    private void OnEnable()
    {
        _inputReader.MoveEvent += OnMove;
    }

    private void OnDisable()
    {
        _inputReader.MoveEvent -= OnMove;
    }

    public void OnMove(Vector2 inputVector)
    {
        InputVector = inputVector;
    }
}