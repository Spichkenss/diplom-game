using UnityEngine;

public class Interactor : MonoBehaviour
{
    public void OnInteract()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 1f);
        foreach (Collider collider in colliders)
        {
            if (collider.TryGetComponent<Interactable>(out Interactable interactable))
            {
                interactable.Interact();
            }
        }
    }
}