using System.Collections;
using UnityEngine;

public class Breaker : MonoBehaviour
{
    private Breakable _currentBreakable;
    private Coroutine _damageCoroutine;
    private bool _isInsideCollider;

    public bool IsBreakingSomething { get; set; }
    
    [field: SerializeField] public float Damage { get; set; } 

    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(out Breakable breakable)) return;
        _isInsideCollider = true;
        _currentBreakable = breakable;
        _damageCoroutine ??= StartCoroutine(DamageBuilding());
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.TryGetComponent(out Breakable breakable)) return;
        _isInsideCollider = false;
        if (_currentBreakable != breakable || _damageCoroutine == null) return;
        StopCoroutine(_damageCoroutine);
        _damageCoroutine = null;
    }

    private IEnumerator DamageBuilding()
    {
        while (_isInsideCollider)
        {
            yield return new WaitForSeconds(1f);
            if (_currentBreakable != null)
                _currentBreakable.TakeDamage(Damage);
        }
    }
}