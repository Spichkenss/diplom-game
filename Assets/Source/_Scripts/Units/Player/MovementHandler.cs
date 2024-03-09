using System;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class MovementHandler : MonoBehaviour
{
    [NonSerialized] public Vector3 MovementVector;
    [NonSerialized] public Vector2 InputVector;

    public void OnMove(Vector2 inputVector)
    {
        InputVector = inputVector;
    }
}
