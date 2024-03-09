using System;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class MovementHandler : MonoBehaviour
{
    [NonSerialized] public Vector3 MovementVector;
    [NonSerialized] public Vector2 InputVector;

    [SerializeField] private InputReader _inputReader;

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
