using System;
using System.Collections;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected Transform _muzzle;
    [SerializeField] protected WeaponData _weaponData;

    protected float _timeSinceLastShot;

    public abstract void Shoot();

    protected bool IsAmmoLeft()
    {
        return _weaponData.currentAmmo > 0;
    }

    protected bool IsCanShoot()
    {
        return !_weaponData.isReloading && _timeSinceLastShot > 1f / (_weaponData.fireRate * 60f);
    }

    protected void StartReloading()
    {
        if (!_weaponData.isReloading)
        {
            StartCoroutine(Reload());
        }
    }

    private IEnumerator Reload()
    {
        Debug.Log("Reload start");
        _weaponData.isReloading = true;
        yield return new WaitForSeconds(_weaponData.reloadTime);

        var diff = _weaponData.magazineSize - _weaponData.currentAmmo;
        if (diff > _weaponData.extraAmmo)
        {
            _weaponData.extraAmmo -= diff;
            _weaponData.currentAmmo += diff;
        }

        _weaponData.isReloading = false;
        Debug.Log("Reload end");
    }

    private void Update()
    {
        _timeSinceLastShot += Time.deltaTime;
        Debug.DrawRay(_muzzle.position, _muzzle.forward);
    }
}

