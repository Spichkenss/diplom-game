using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "SO_WeaponData", menuName = "Scriptable Objects/Weapon/SO_WeaponData")]
public class WeaponData : ScriptableObject
{
    [Header("Information")]
    public string weaponName;

    [Header("Combat stats")]
    public float damage;
    public float maxDistance;

    [Header("Ammo")]
    public int currentAmmo;
    public int magazineSize;
    public int extraAmmo;

    [Header("Shooting")]
    public float fireRate;

    [Header("Reloading")]
    public float reloadTime;
    [HideInInspector]
    public bool isReloading;
}
