using System;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class MovementHandler : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;

    [NonSerialized] public Vector3 MovementVector;
    [NonSerialized] public Vector2 InputVector;

    private void OnEnable()
    {
        _inputReader.MoveEvent += OnMove;
    }

    private void OnDisable()
    {
        _inputReader.MoveEvent -= OnMove;
    }

    private void OnMove(Vector2 inputVector)
    {
        InputVector = inputVector;
    }
}
