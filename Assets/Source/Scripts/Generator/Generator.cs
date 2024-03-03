using UnityEngine;

namespace Source.Scripts.Generator
{
    public class Generator : MonoBehaviour, IInteractable
    {
        public void Interact()
        {
            Debug.Log("Generator interacted");
        }
    }
}
