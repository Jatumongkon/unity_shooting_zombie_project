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
    public float fireRate = 2.0f;
    

    private float horizontal;
    private float vertical;
    private Animator animator; 
    private Rigidbody2D rb;
    private bool canFire = true;





    // Start is called before the first frame update
    void Start()
    {


        animator = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("Run", false);
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        moveDirection = new Vector2(horizontal, vertical);
        
        // transform.Translate(moveDirection * speed * Time.deltaTime);
        //rb.AddForce(moveDirection * speed * Time.deltaTime , ForceMode2D.Impulse);
        //rb.velocity = moveDirection* speed ;

        if (horizontal != 0 || vertical != 0 )
        {
            animator.SetBool("Run", true);
           
        }
        if (Input.GetMouseButton(0))
        {
            fire();
        }

  

    }
    private void FixedUpdate()
    {
        rb.AddForce(moveDirection * speed * Time.deltaTime, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {


    }
    private void fire()
    {
        if (canFire)
        {
            Instantiate(bullet, gun.transform.position, aim.transform.rotation );
            canFire = false;
            StartCoroutine(reload());
        }
        
    }

    IEnumerator reload()
    {
        yield return new WaitForSeconds(fireRate);
        canFire = true;
    }
}
