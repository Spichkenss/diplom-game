using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "SO_WeaponData", menuName = "Scriptable Objects/Weapon/SO_WeaponData")]
public class WeaponData : ScriptableObject
{
    [Header("Information")]
    public string weaponName = default;

    [Header("Combat stats")]
    public float damage = default;
    public float maxDistance = default;

    [Header("Ammo")]
    public int currentAmmo = default;
    public int magazineSize = default;
    public int extraAmmo = default;

    [Header("Shooting")]
    public float fireRate = default;

    [Header("Reloading")]
    public float reloadTime = default;
    [HideInInspector] public bool isReloading = false;
}
