using System;
using UnityEngine;

public class RotationHandler : MonoBehaviour
{
    [NonSerialized] public Vector2 MousePosition;

    public void OnLook(Vector2 mousePosition)
    {
        MousePosition = mousePosition;
    }
}
