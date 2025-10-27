using UnityEngine;

//this script will be attached to all weapon prefabs
//it will handle pointing the weapon in the direction of the mouse.
public class WeaponAim : MonoBehaviour
{ 

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
            transform.localScale = new Vector3(1, -1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        
    }
}
