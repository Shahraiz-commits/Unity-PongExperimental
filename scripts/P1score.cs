using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class P1score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.name == "ball"){
            score++;
            scoreText.text = score.ToString();
        }
    }
}
