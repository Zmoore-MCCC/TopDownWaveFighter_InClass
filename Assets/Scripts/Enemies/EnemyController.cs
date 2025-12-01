using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform target;
    public float moveSpeed;
    private Animator animator;
    public float health;
    private bool isDead;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //get a reference to the player
        target = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isDead)
        {
            moveTowardsPlayer();
            checkIfDead();
        }

    }

    private void moveTowardsPlayer()
    {
        //catch statement to make sure the game does not break
        if(target == null)
        {
            return;
        }

        transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

        //float moveX = Input.GetAxisRaw("Horizontal");

        //if(moveX > 0)
        //{
        //    transform.eulerAngles = new Vector3 (0, 0, 0);
        //}
        //else if (moveX < 0)
        //{
        //    transform.eulerAngles = new Vector3(0, 180, 0);
        //}

        //transform.LookAt(target);
    }

    private void takeDamage(float damage)
    {
        health -= damage;
    }

    private void checkIfDead()
    {
        if(health <= 0)
        {
            isDead = true;
            animator.SetBool("isDead", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            animator.SetTrigger("isHit");
            takeDamage(collision.gameObject.GetComponent<MoveBullet>().getBulletDamage());
        }
    }

    public void destroyEnemy()
    {
        Destroy(gameObject);
    }
}
