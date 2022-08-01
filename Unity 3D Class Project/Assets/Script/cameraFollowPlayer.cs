using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollowPlayer : MonoBehaviour
{
    public Vector3 offset;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector3 cameraPos = new Vector3(player.position.x,player.position.y ,player.position.z) +offset;
        this.transform.position = cameraPos;
    }
}
