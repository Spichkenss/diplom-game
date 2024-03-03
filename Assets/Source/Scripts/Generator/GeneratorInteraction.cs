using UnityEngine;

namespace Source.Scripts.Generator
{
    public class GeneratorInteraction : InteractableBehaviour
    {
        public override void Interact()
        {
            base.Interact();
            Debug.Log("Generator interacted");
        }
    }
}
