using System;
using UnityEngine;

public class RotationHandler : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [NonSerialized] public Vector2 MousePosition;

    private void OnEnable()
    {
        Cursor.visible = false;
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