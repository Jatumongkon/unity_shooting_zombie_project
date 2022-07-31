using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunScript : MonoBehaviour
{
    float speed = 1;
    private Camera mainCam;
    private Vector3 mousePos;
    private Transform aimTransform;
    public GameObject player;
    private float angle;

    private void Awake()
    {
        aimTransform = transform.Find("Aim");
    }

    private void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        mousePos = Input.mousePosition;
        Vector3 screePoint = Camera.main.WorldToScreenPoint(transform.localPosition);
       
        Vector2 offset = new Vector2(mousePos.x - screePoint.x, mousePos.y - screePoint.y);

        angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg -90;
        //transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }


}
