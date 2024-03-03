using System;
using UnityEngine;

public class RotationHandler : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;

    [NonSerialized] public Vector2 MousePosition;

    private void OnEnable()
    {
        _inputReader.LookEvent += OnLook;
    }

    private void OnDisable()
    {
        _inputReader.LookEvent -= OnLook;
    }

    private void OnLook(Vector2 mousePosition)
    {
        MousePosition = mousePosition;
    }
}
