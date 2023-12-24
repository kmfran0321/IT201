using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    [SerializeField] float bounceAmount = 300f;


   private void OnTriggerEnter(Collider other) {
    //if other collider is the player, then do something 
    if (other.gameObject.CompareTag("Player")) {
        //get the player's ridgidbody
        Rigidbody playerRigidbody = other.gameObject.GetComponent<Rigidbody>();

        //if we found a ridgidbody, apply the force
        if (playerRigidbody != null) {
            //get player's velocity and invert it 
            Vector3 bounceDirection = -playerRigidbody.velocity;
            //apply this force
            playerRigidbody.AddForce(bounceDirection * bounceAmount);
        }
    }
   }
}
