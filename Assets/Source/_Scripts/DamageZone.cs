using UnityEngine;

public class DamageZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Damageable damageable))
        {
            damageable.TakeDamage(10);
        }
    }
}
