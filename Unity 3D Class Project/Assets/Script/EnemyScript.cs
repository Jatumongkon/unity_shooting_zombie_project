using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    public int enemyHp = 5;
    Transform target;
    private Animator animator;
    public Vector2 distance;
    private Vector2 moveDirection;
    public float speed = 1;
    private Rigidbody2D rigidbody;
    public float offset;
    private bool isAttack = false;

    void Start()
    {
        
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
       
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }

    }

    // Update is called once per frame
    void Update()
    {

        distance = target.transform.position - this.transform.position;
        if(distance.x < 0)
        {
            moveDirection.x = -1;
        }
        if (distance.x > 0)
        {
            moveDirection.x = 1;
        }
        if (distance.y < 0)
        {
            moveDirection.y = -1;
        }
        if (distance.y > 0)
        {
            moveDirection.y = 1;
        }
        
        print(Vector2.Distance(distance, new Vector2(0, 0)));
        if(Vector2.Distance(distance, new Vector2 (0,0)) < offset)
        {
            attack();
        }

        else
        {
            Enemymove();
        }


        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            attack();
            isAttack = false;
        }
    }

    private void attack()
    {
        animator.SetBool("Run", false);
        animator.SetBool("Attack", true);
    }
    private void Enemymove()
    {
        animator.SetBool("Attack", false);
        animator.SetBool("Run", true);
        rigidbody.AddForce(moveDirection * speed * Time.deltaTime, ForceMode2D.Impulse);
    }

}
