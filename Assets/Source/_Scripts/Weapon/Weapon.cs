using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;

    [NonSerialized] public bool IsShootingHolding;
    [NonSerialized] public float FireCooldown = 0f;

    public Transform Muzzle;
    public WeaponData WeaponData;
    public RigBuilder RigBuilder;

    public abstract void Shoot();

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

    private void OnShootingHold(bool state)
    {
        IsShootingHolding = state;
    }

    private void OnReloadingPressed()
    {
        Debug.Log($"{WeaponData.currentAmmo}, {WeaponData.magazineSize}");
        WeaponData.isReloading = WeaponData.currentAmmo != WeaponData.magazineSize;
    }

    public void StartReloading()
    {
        StartCoroutine(Reload());
    }

    private IEnumerator Reload()
    {
        Debug.Log("Reload start");

        WeaponData.isReloading = true;

        lock (WeaponData)
        {
            yield return new WaitForSeconds(WeaponData.reloadTime);

            WeaponData.currentAmmo = 30;

            // var diff = WeaponData.magazineSize - WeaponData.currentAmmo;
            // if (diff > WeaponData.extraAmmo)
            // {
            //     WeaponData.extraAmmo -= diff;
            //     WeaponData.currentAmmo += diff;
            // }
        }

        WeaponData.isReloading = false;
        Debug.Log("Reload end");
    }
}

