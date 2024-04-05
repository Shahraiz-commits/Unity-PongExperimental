using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public float boostSpeed;
    public bool isPlayer1;
    public Rigidbody2D rb = new Rigidbody2D();
    private float move;
    private bool usedBoost = false;
    
    // Update is called once per frame
    void Update()
    {
        if (isPlayer1){
            move = Input.GetAxisRaw("Vertical");
            if(Input.GetAxisRaw("boost") != 0) usedBoost = true;
            else usedBoost = false;
        }
        else{
            move = Input.GetAxisRaw("Vertical2");
             if(Input.GetAxisRaw("boost2") != 0) usedBoost = true;
              else usedBoost = false;
        }
        
        if(usedBoost)
        { 
            rb.velocity = new Vector2(0, move*speed*boostSpeed); //increase speed
            
        }
        else rb.velocity = new Vector2(0, move*speed);
    }
}
