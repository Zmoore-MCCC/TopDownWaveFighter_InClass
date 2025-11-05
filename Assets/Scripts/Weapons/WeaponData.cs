using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "Scriptable Objects/WeaponData")]
public class WeaponData : ScriptableObject
{
    [Header("Stats")]
    public string weaponName;
    public float fireRate;
    public float bulletSpeed;
    public int damage;
    public int ammo;
    public float spread;
    public float realoadTime;

    [Header("References (Drag/Drop)")]
    public GameObject bulletPrefab;
    public AudioClip fireSound;
    public Sprite weaponSprite;

    [Header("Upgrade Multiplier")]
    public float fireRateUpgrade;
    public float damageUpgrade;
    public float bulletSpeedUpgrade;
}
