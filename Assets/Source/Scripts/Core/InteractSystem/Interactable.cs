using UnityEngine;

public class InteractableBehaviour : MonoBehaviour
{
    [SerializeField] protected string _objectName;

    public virtual void Interact()
    {
        Debug.Log($"Interacted with {_objectName}");
    }
}
