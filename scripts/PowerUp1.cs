using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp1 : MonoBehaviour
{
    public ParticleSystem particleSys;
    public Rigidbody2D ball;
    public float powerUp1Speed;
    public int powerUps1Left;
    private bool inUse;
    // Start is called before the first frame update
    void Start()
    {
        inUse = false;
    }
    
    void Update(){
         if(Input.GetKeyDown(KeyCode.F)){
            if(powerUps1Left != 0 && !inUse){
                inUse = true;
                powerUps1Left--;
                UsePowerUp1();
            }
            else if (powerUps1Left == 0) PlaceHolder();
        }
        inUse = false; 
    }

    // indicate that powerups finished
    void PlaceHolder(){
        Debug.Log("Youre out of powerups");
    }
    void UsePowerUp1(){
        Debug.Log("Using powerup -- The name of the object is  " + ball.name );
        StartCoroutine(FreezeScreen());
        
        // Make ball go zoom (towards player 2)
        ball.velocity = new(ball.velocity.x, 0); // Stop in y direction
        Vector2 force = new Vector2(Mathf.Abs(ball.velocity.x*powerUp1Speed), 0);
        ball.AddForce(force, ForceMode2D.Impulse); // Apply force in x direction
        // Emit effects from ball
        //Ball currently already has a set of effects. This is just calling play on those ones :/
        var emission = particleSys.emission;
        emission.enabled = true;

        particleSys.Play();
    }

    // Return type IEnumerator means this is a courotine.
    // Courotines can execute over multiiple frames instead of reaching completion
    // over a single frame. Useful for animations/delays
    IEnumerator FreezeScreen()
    {
        float originalTimeScale = Time.timeScale;
        Time.timeScale = 0f;
        // Wait for half a second in real time (independent of time scale)
        yield return new WaitForSecondsRealtime(1.0f);
        
        // Restore the original time scale
        Time.timeScale = originalTimeScale;
    }
}
