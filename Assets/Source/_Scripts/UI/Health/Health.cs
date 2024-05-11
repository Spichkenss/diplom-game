using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [HideInInspector] public float currentValue;
    
    public float maxValue = 100;
    public UnityAction<float> HealthChanged = delegate { };
    public UnityAction UnitDied = delegate { };

    private void Awake()
    {
        currentValue = maxValue;
    }

    public float Increase(float amount)
    {
        currentValue += amount;
        if (currentValue > maxValue) currentValue = maxValue;
        HealthChanged.Invoke(currentValue);
        return currentValue;
    }

    public float Decrease(float amount)
    {
        currentValue -= amount;
        if (currentValue < 0)
        {
            currentValue = 0;
            UnitDied.Invoke();
        }
        HealthChanged.Invoke(currentValue);
        return currentValue;
    }
}