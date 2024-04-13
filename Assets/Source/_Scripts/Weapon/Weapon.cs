using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.Events;

public class Weapon : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [NonSerialized] public float FireCooldown = 0f;
    [NonSerialized] public bool IsShootingHolding;

    public MuzzleController Muzzle;
    public WeaponData WeaponData;
    public RigBuilder RigBuilder;

    public event UnityAction ShotFired = delegate { };

    private void OnEnable()
    {
        _inputReader.ShootEvent += OnShootingHold;
        _inputReader.ReloadEvent += OnReloadingPressed;
    }

    private void OnDisable()
    {
        _inputReader.ShootEvent -= OnShootingHold;
        _inputReader.ReloadEvent -= OnReloadingPressed;
    }

    public virtual void Shoot()
    {
        ShotFired.Invoke();
    }

    private void OnShootingHold(bool state)
    {
        IsShootingHolding = state;
    }

    private void OnReloadingPressed()
    {
        WeaponData.isReloading = WeaponData.currentAmmo != WeaponData.magazineSize;
    }

    public void StartReloading()
    {
        StartCoroutine(Reload());
    }

    private IEnumerator Reload()
    {
        WeaponData.isReloading = true;

        lock (WeaponData)
        {
            yield return new WaitForSeconds(WeaponData.reloadTime);

            var diff = WeaponData.magazineSize - WeaponData.currentAmmo;

            if (WeaponData.extraAmmo - diff <= 0)
            {
                diff = WeaponData.extraAmmo;
            }
            WeaponData.currentAmmo += diff;
            WeaponData.extraAmmo -= diff;

        }

        WeaponData.isReloading = false;
    }
}
