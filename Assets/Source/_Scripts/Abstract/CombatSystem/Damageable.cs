using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Health))]
public class Damageable : MonoBehaviour
{
    [SerializeField] private Health _health;

    public UnityAction RanOutOfHealth = delegate { };

    public void TakeDamage(float damage)
    {
        var updatedHealth = _health.Decrease(damage);

        if (updatedHealth <= 0) RanOutOfHealth.Invoke();
    }
}