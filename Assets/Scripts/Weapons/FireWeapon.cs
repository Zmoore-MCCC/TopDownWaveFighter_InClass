using UnityEngine;

public class FireWeapon : MonoBehaviour
{
    //References made in Unity
    [Header("References")]
    public GameObject bullet;
    public Transform muzzle;

    //Set values in Unity
    [Header("Stats")]
    public float fireRate;

    //Computed Values in Code
    private float timeBetweenShots;
    private bool canFire;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canFire = true;   
    }

    // Update is called once per frame
    void Update()
    {
        //If the timeBetweenShots is less than or equal to zero I can shoot
        if(timeBetweenShots <= 0)
        {
            //I can shoot the weapon
            canFire = true;
            //reset timeBetweenShots to the specified firingRate
            timeBetweenShots = fireRate;
        }
        else
        {
            //I cannot shoot yet
            //I will deduct time from timeBetweenShots until it is 0 allowing
            //the player to fire their weapon again
            timeBetweenShots -= Time.deltaTime;
        }

        //if the left mouse was clicked
        if(Input.GetButtonDown("Fire1"))
        {
            //the player has clicked the left mouse button
            if(canFire)
            {
                //After you fire you have to wait a specified amount of time
                //to fire again so the boolean to false
                canFire = false;
                shootWeapon();
            }
        }
    }

    void shootWeapon()
    {
        //we need to create a bullet at the position of the muzzle 
        //given the players rotation
        Instantiate(bullet, muzzle.position, transform.rotation);
    }
}
