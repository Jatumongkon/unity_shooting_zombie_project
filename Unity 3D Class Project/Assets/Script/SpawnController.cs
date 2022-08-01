using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{

    private float spawnX = 10.0f;
    private float spawnY = 12.0f;
    public GameObject zombie;
    public gameLogi logi;
    public float timeElapsed = 0.0f;
    public float ItemCycle = 1.0f;
    public GameObject powerUp;
    private int powerUpCount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;

        powerUpCount =  GameObject.FindGameObjectsWithTag("Item").Length;
        if(powerUpCount< 3)
        {
            Instantiate(powerUp, new Vector3(Random.Range(-spawnX, spawnX), Random.Range(-spawnY, spawnY), 0.0f), powerUp.transform.rotation);
        }
        


        if (timeElapsed > ItemCycle)
        {
            Instantiate(zombie, new Vector3(Random.Range(-spawnX, spawnX), Random.Range(-spawnY, spawnY), 0.0f), zombie.transform.rotation);
            timeElapsed = 0;
        }
        
    }
}
