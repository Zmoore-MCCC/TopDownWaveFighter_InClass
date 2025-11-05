//====================================================================
//Author   : Zackary Moore
//Date     : 11-05-2025
//Desc     : Keeps track of all weapons that are available in the game.
//           Responsible for dropping new weapons.
//Type     : Singleton
//Attached : GameManger Object
//====================================================================


using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    //Singleton so there is only one instance of this throughout the game
    //I only want one instance becuase I want this script to keep track of
    //weapons that are currently active in the game so we do not drop the same
    //weapons
    public static WeaponManager Instance { get; private set; }

    //keep track of all weapons possible in game
    public List<WeaponData> listOfWeapons;
    //Which prefab to add to game
    public GameObject weaponPrefab;

    private void Awake()
    {
        //if there is an instance of this gameobject that already exists delete it
        //to ensure we only ever have one copy
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    //Spawn a random weapon
    //we can spawn a weapon two ways: in the player's hands or in the world
    //we will set parent to null by default.  Just becuase a weapon is spawned does not
    //mean it is equipped to the player.  However, if we buy a weapon from the store
    //we could spawn the weapon as a child to the player
    public WeaponController spawnRandomWeapon(Vector3 position, Transform parent = null)
    {
        int randomIndex = Random.Range(0,listOfWeapons.Count);

        //pick a random weapon from our list using the random number
        WeaponData weaponData = listOfWeapons[randomIndex];

        //Instantiate the weapon prefab
        GameObject weaponObj = Instantiate(weaponPrefab, position, Quaternion.identity, parent);

        //this weaponobj has a weaponcontroller script attached to it
        //this is what I will use to set this weapons given data
        WeaponController weapon = weaponObj.GetComponent<WeaponController>();

        //initialize the weapon with the given data
        weapon.Initialize(weaponData);

        return weapon;
    }

    public WeaponData GetRandomWeapon()
    {
        return listOfWeapons[Random.Range(0, listOfWeapons.Count)];
    }
}
