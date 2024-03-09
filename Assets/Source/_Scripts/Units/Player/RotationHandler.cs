using System;
using UnityEngine;

public class RotationHandler : MonoBehaviour
{
    [NonSerialized] public Vector2 MousePosition;

    [SerializeField] private InputReader _inputReader;

    private void OnEnable()
    {
        _inputReader.LookEvent += OnLook;
    }

    private void OnDisable()
    {
        _inputReader.LookEvent -= OnLook;
    }

    public void OnLook(Vector2 mousePosition)
    {
        MousePosition = mousePosition;
    }
}
