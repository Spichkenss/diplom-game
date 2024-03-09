using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breaker : MonoBehaviour
{
    private bool _isInsideCollider;
    private Breakable _currentBreakable;
    private Coroutine _damageCoroutine;

    public bool IsBreakingSomething { get; private set; }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent<Breakable>(out Breakable breakable)) return;
        _isInsideCollider = true;
        _currentBreakable = breakable;
        if (_damageCoroutine == null)
            _damageCoroutine = StartCoroutine(DamageBuilding());
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.TryGetComponent<Breakable>(out Breakable breakable)) return;
        _isInsideCollider = false;
        if (_currentBreakable == breakable && _damageCoroutine != null)
        {
            StopCoroutine(_damageCoroutine);
            _damageCoroutine = null;
        }
    }

    private IEnumerator DamageBuilding()
    {
        while (_isInsideCollider)
        {
            yield return new WaitForSeconds(1f);
            if (_currentBreakable != null)
                _currentBreakable.TakeDamage(10f);
        }
    }
}
