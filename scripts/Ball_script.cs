using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEditor.Callbacks;
using UnityEditor.U2D.Path;
using UnityEngine;

public class Ball_script : MonoBehaviour
{
    public float speed;
    private float maxSpeed;
    public Rigidbody2D rb;
    public ParticleSystem ballParticle;
    public Light halo;  

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D component not found!");
        }
        else
        {
            FindObjectOfType<AudioManager>().Play("bg music 1");
            Debug.Log("LAUNCHING BALL");
            Launch();
        }
            
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G)){
        Vector2 force = new Vector2(rb.velocity.x*5, 0);
        rb.AddForce(force, ForceMode2D.Impulse);
    }
    }

    //launch the ball when the round starts
    private void Launch(){
        float launchX;
        float launchY;
        do{
        launchX = Random.Range(-3.0f,3.0f);
        launchY = Random.Range(-3.0f,3.0f);
        } while(Mathf.Abs(launchX) <= 1.5f && Mathf.Abs(launchY) <= 1.5f);
        rb.velocity = new Vector2(launchX * speed, launchY * speed);
    }

    [System.Obsolete]
    void OnCollisionEnter2D(Collision2D collision){
        //Particle effects upon collision of the ball
        
        //Play hit sound
        FindObjectOfType<AudioManager>().Play("hit sound 1");
       
        //Rebound after goal
       // rebound(collision.gameObject.name);

        //Speed of the ball changed upon collision
        SpeedResponse(collision.rigidbody.velocity);
    }

    private void SpeedResponse(Vector2 velocity){
        maxSpeed = speed * 5;
        if(velocity.y > speed) {
            Vector2 tempSpeed = new Vector2((float)(speed * velocity.x * 2.0), (float)(speed * velocity.y * 2.0)); 
            if (tempSpeed.x <= maxSpeed && tempSpeed.y <= maxSpeed) rb.velocity = tempSpeed;
            else rb.velocity = new Vector2(maxSpeed, maxSpeed);
        }
    }

    private void Rebound(string name){
        if(name == "player 1 goal") {
            rb.velocity = Vector2.zero;
        } 
    }
}
