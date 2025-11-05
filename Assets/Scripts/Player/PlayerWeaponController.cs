using System.Xml.Serialization;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{
    //needs to have referene to the location to place this weapon on player
    public Transform weaponHolder;
    //have reference to the equipped weapon
    private WeaponController currentWeapon;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        getRandomWeapon();
    }

    private void getRandomWeapon()
    {
        WeaponData weapon = WeaponManager.Instance.GetRandomWeapon();
        equipWeapon(weapon);
    }

    private void equipWeapon(WeaponData weapon)
    {
        if(currentWeapon != null)
        {
            Destroy(currentWeapon);
        }

        GameObject weaponObj = Instantiate(WeaponManager.Instance.weaponPrefab, weaponHolder);
        currentWeapon = weaponObj.GetComponent<WeaponController>();
        currentWeapon.Initialize(weapon);
    }
}
