using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public int hp = 10;
    public float speed = 10.0f;
    public Vector2 moveDirection;
    public GameObject powerUp;
    public GameObject aim;
    public GameObject gun;
    public GameObject bullet;
    public float fireRate = 1.0f;

    public AudioSource gunAudio;
    public AudioSource AudioPowerUp;

    private float horizontal;
    private float vertical;
    private Animator animator; 
    private Rigidbody2D rb;
    private bool canFire = true;
    public bool isDead = false;
    public float timePowerUp = 0.0f;
    public bool isPowerUp = false;

    public ParticleSystem blood;



    // Start is called before the first frame update
    void Start()
    {


        animator = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            animator.SetBool("Run", false);
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");
            moveDirection = new Vector2(horizontal, vertical);


            if (horizontal != 0 || vertical != 0)
            {
                animator.SetBool("Run", true);

            }
            if (Input.GetMouseButton(0))
            {
                fire();
            }
        }

        if (this.hp <= 0)
        {
            this.hp = 0;
            isDead = true;
        }
        if (this.isPowerUp)
        {
            
            fireRate = 0.1f;
            speed = 50f;
            timePowerUp += Time.deltaTime;
            if(timePowerUp >= 5.0f)
            {
                timePowerUp = 0.0f;
                isPowerUp = false;
            }

        }
        if (!isPowerUp)
        {
            speed = 20.0f;
            fireRate = 0.5f;
            isPowerUp = false;
        }


    }
    private void FixedUpdate()
    {
        if (!isDead)
            rb.AddForce(moveDirection * speed * Time.deltaTime, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Item")
        {
            isPowerUp = true;
            AudioPowerUp.Play();
            timePowerUp = 0.0f;
        }

    }
    public void bloodLast()
    {
        blood.Play();
    }


    private void fire()
    {
        if (canFire)
        {
            Instantiate(bullet, gun.transform.position, aim.transform.rotation );
            canFire = false;
            gunAudio.Play();
            StartCoroutine(reload());
        }
        
    }   

    IEnumerator reload()
    {
        gunAudio.Play();
        yield return new WaitForSeconds(fireRate);
        canFire = true;
    }
}
