using UnityEngine;

public class Interactor : MonoBehaviour
{
    public void OnInteract()
    {
        var colliders = Physics.OverlapSphere(transform.position, 1f);
        foreach (var collider in colliders)
            if (collider.TryGetComponent(out Interactable interactable))
                interactable.Interact();
    }
}