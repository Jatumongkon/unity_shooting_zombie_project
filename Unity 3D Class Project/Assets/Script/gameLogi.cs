using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameLogi : MonoBehaviour
{
    public Text Texthp;
    public Text Textscore;
    public float score = 0;
    public playerController player;
    public GameObject zombie;
    public GameObject gameOver;
    private SceneManagerClass sceneManagerClass;

    private float timeToload = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        player = player.GetComponent<playerController>();
        sceneManagerClass = gameObject.GetComponent<SceneManagerClass>();



    }

    // Update is called once per frame
    void Update()
    {
        Texthp.text = "Hp : " + player.hp;
        Textscore.text = "Score : " + score;

        if(player.hp <= 0)
        {
            timeToload += Time.deltaTime;
            Texthp.text = "Dead";
            gameOver.SetActive(true);
            gameOver.transform.position = player.transform.position;
    
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            print("Quit");
            Application.Quit();
        }

    }
    private void FixedUpdate()
    {

        if (timeToload >10.0f)
        {
            SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
            
        }
    }




}
