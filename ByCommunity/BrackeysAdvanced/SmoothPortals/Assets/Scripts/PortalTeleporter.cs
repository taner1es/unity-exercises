using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleporter : MonoBehaviour
{
    public CharacterController player;
    public Transform receiver;

    private bool playerIsOverlapping = false;

    private void Update() {
        if(playerIsOverlapping){
            Vector3 portalToPlayer = player.transform.position - transform.position;
            float dotProduct = Vector3.Dot(transform.up, portalToPlayer);

            // dot product is less then zero means, the player has moved across the portal
            if(dotProduct < 0f){
                // teleporting
                float rotationDiff = -Quaternion.Angle(transform.rotation, receiver.rotation);
                rotationDiff += 180;
                player.transform.Rotate(Vector3.up, rotationDiff);

                Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToPlayer;
                player.enabled = false;
                player.transform.position = receiver.position + positionOffset;
                player.enabled = true;

                playerIsOverlapping = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            playerIsOverlapping = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.tag == "Player"){
            playerIsOverlapping = false;
        }
    }
}
