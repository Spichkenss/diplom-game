using UnityEngine;

public class Generator : Interactable
{
    [SerializeField] private string _objectName;

    public override void Interact()
    {
        Debug.Log("Generator interacted " + _objectName);
    }
}
