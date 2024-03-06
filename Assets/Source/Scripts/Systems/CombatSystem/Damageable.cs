using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damageable : MonoBehaviour
{
    [SerializeField] private Health _health;

    public UnityAction RanOutOfHealth = delegate { };

    public void TakeDamage(float damage)
    {
        float updatedHealth = _health.Decrease(damage);

        if (updatedHealth <= 0)
        {
            RanOutOfHealth.Invoke();
        }
        Debug.Log("Health: " + updatedHealth);
    }
}
