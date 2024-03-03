using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField, Range(0f, 5f)] private float _interactionRange = 2f;
    public void OnInteract()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _interactionRange);
        foreach (var collider in colliders)
        {
            if (collider.TryGetComponent(out InteractableBehaviour interactable))
            {
                interactable.Interact();
            }
        }
    }
}
