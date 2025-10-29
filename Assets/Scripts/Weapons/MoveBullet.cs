using UnityEngine;

public class MoveBullet : MonoBehaviour
{
    //information filled in the unity editor about a bullet
    [Header("Stats")]
    public float bulletDamage;
    public float bulletSpeed;
    public float bulletLife;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //call the destroyBullet function after bulletLife seconds
        Invoke("destroyBullet", bulletLife);
    }

    // Update is called once per frame
    void Update()
    {
        //move the bullet
        //we can use translate to move the bullet as long as either the bullet
        //or the enemy contains a rigidbody
        //You cannot detect collisions unless one of the game objects has a rigidbody
        transform.Translate(Vector2.right * bulletSpeed * Time.deltaTime);
    }

    void destroyBullet()
    {
        //remove the bullet from the screen
        Destroy(this.gameObject);
    }
}
