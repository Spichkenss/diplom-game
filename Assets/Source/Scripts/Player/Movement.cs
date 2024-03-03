using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;

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
        Debug.Log(inputVector);
    }

    private void Start()
    {
        Debug.Log("Hello World!");
    }
}
