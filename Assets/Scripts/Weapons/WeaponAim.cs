using UnityEngine;

//this script will be attached to all weapon prefabs
//it will handle pointing the weapon in the direction of the mouse.
public class WeaponAim : MonoBehaviour
{
    //needed to make the connection between the weapon and the player
    //the weapon will be attached to the player so I can get a reference to the player
    //I am using this to rotate the player based off the weapon rotation.
    private Transform player;

    private void Start()
    {
        //This script is attached to the weapon
        //and the weapon is a child of the player
        player = transform.parent;
    }
    // Update is called once per frame
    void Update()
    {
        //get the mouse pos
        Vector3 mousePos = Input.mousePosition;
        //set z of mousePos
        mousePos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        //get world position of mouse
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePos);

        Vector3 direction = mouseWorldPos - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        if(angle > 90 || angle < -90)
        {
            player.localScale = new Vector3(-1, 1, 1);
            transform.localScale = new Vector3(-1, -1, 1);
            
        }
        else
        {
            player.localScale = new Vector3(1, 1, 1);
            transform.localScale = new Vector3(1, 1, 1);
            
        }
        
    }
}
