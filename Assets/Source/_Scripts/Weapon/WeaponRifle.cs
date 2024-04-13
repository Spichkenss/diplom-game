using UnityEngine;

public class WeaponRifle : Weapon
{
    public override void Shoot()
    {
        var muzzleTransform = Muzzle.transform;
        if (Physics.Raycast(muzzleTransform.position, muzzleTransform.forward, out var hitInfo, WeaponData.maxDistance))
            if (hitInfo.transform.TryGetComponent(out Damageable damageable))
                damageable.TakeDamage(WeaponData.damage);

        base.Shoot();
    }
}