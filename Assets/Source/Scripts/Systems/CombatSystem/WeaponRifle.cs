using UnityEngine;

public class WeaponRifle : Weapon
{
    public override void Shoot()
    {
        if (!IsAmmoLeft()) return;
        if (!IsCanShoot()) return;

        if (Physics.Raycast(_muzzle.position, _muzzle.forward, out RaycastHit hitInfo, _weaponData.maxDistance))
        {
            Debug.Log(hitInfo);
            if (hitInfo.transform.TryGetComponent<Damageable>(out Damageable damageable))
            {
                damageable.TakeDamage(_weaponData.damage);
            }
        }

        _weaponData.currentAmmo--;
        _timeSinceLastShot = 0f;
    }
}
