using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 5; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

            Destroy(this.gameObject);
        

    }


  private void OnTriggerEnter2D(Collider2D collision)
    {
       
            if(collision.tag != "Player")
        {
            Destroy(this.gameObject);
        }
        
   }
}
