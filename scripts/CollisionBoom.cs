using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollisionBoom : MonoBehaviour
{
    public ParticleSystem particleSys;
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "ball"){
            var emission = particleSys.emission;
            emission.enabled = true;

            particleSys.Play();
        }
    }

    /*
    private void OnCollisionExit2D(Collision2D collision){
        var emission = particleSys.emission;
        emission.enabled = false;
    }
    */
    
}
