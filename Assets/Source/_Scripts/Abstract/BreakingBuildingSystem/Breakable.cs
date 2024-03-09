using UnityEngine;
using UnityEngine.Events;

public class Breakable : MonoBehaviour
{
    [SerializeField] private Health _health;

    public UnityAction WasBroken = delegate { };

    public void TakeDamage(float damage)
    {
        float updatedHealth = _health.Decrease(damage);

        if (updatedHealth <= 0)
        {
            WasBroken.Invoke();
            Destroy(gameObject);
        }
    }
}