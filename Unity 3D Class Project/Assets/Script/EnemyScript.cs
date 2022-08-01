using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    public int enemyHp = 3;
    Transform target;
    private Animator animator;
    public Vector2 distance;
    private Vector2 moveDirection;
    public float speed = 1;
    private Rigidbody2D rigidbody;
    public float offset;
    private bool canAttack = true;
    private gameLogi logi;
    private playerController player;
    private GameObject playerObject;
    public GameObject blood;
    public bool isDead = false;
    public ParticleSystem shot;

    public AudioSource[] zombieAudio;

    public GameObject gameLogi;
   

    void Start()
    {
        gameLogi = GameObject.FindGameObjectWithTag("GameController");
        logi = gameLogi.GetComponent<gameLogi>();
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
       
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
            playerObject = GameObject.FindGameObjectWithTag("Player");
            player = playerObject.GetComponent<playerController>();
        }
        int temp = Random.Range(0, 2);
        if (temp < 1.0f)
        {
            zombieAudio[Random.Range(0, zombieAudio.Length)].Play();
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

        print(offset);
        if(Vector2.Distance(distance, new Vector2 (0,0)) < offset)
        {
            attack();
        }
        if (this.enemyHp <=0)
        {
            this.enemyHp = 0;
            isDead = true;
            animator.SetBool("Dead", true);
            StartCoroutine(destroyObject());
        }

        if (Vector2.Distance(distance, new Vector2(0, 0)) > offset && this.enemyHp > 0)
        {
            Enemymove();
        }


        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.tag == "Bullet")
        {
            this.enemyHp -= 1;
            shot.Play();
        }

    }

    private void attack()
    {
        if (canAttack && !isDead)
        {
            animator.SetBool("Run", false);
            animator.SetBool("Attack", true);
            canAttack = false;
            StartCoroutine(waitForNextAttack());
            Instantiate(blood, playerObject.transform.position, blood.transform.rotation);
            player.hp -= 1;
            player.bloodLast();
        }
        //player.hp -= 1;
    }
    private void Enemymove()
    {
        animator.SetBool("Attack", false);
        animator.SetBool("Run", true);
        rigidbody.AddForce(moveDirection * speed * Time.deltaTime, ForceMode2D.Impulse);
    }

    IEnumerator destroyObject()
    {
        
        yield return new WaitForSeconds(1.0f);
        logi.score += 5;
        Destroy(gameObject);
    }

    IEnumerator waitForNextAttack()
    {
        
        yield return new WaitForSeconds(1f);
        canAttack = true; 
    }

}
