using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameLogi : MonoBehaviour
{
    public Text Texthp;
    public Text Textscore;
    public float score = 0;
    public playerController player;
    public GameObject zombie;




    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        player = player.GetComponent<playerController>();

        
    }

    // Update is called once per frame
    void Update()
    {
        Texthp.text = "Hp : " + player.hp;
        Textscore.text = "Score : " + score;
    }


}
