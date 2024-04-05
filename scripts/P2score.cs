using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class P2score : MonoBehaviour
{

    public TextMeshProUGUI scoreText; 
    private int score = 0;
    
      private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.name == "ball"){
            score++;
            scoreText.text = score.ToString();
        }
    }
}
