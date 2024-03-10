using UnityEngine;

public class WeaponRifle : Weapon
{
    public override void Shoot()
    {
        if (Physics.Raycast(Muzzle.position, Muzzle.forward, out RaycastHit hitInfo, WeaponData.maxDistance))
        {
            if (hitInfo.transform.TryGetComponent<Damageable>(out Damageable damageable))
            {
                damageable.TakeDamage(WeaponData.damage);
            }
        }
    }
}
