using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUp : MonoBehaviour
{

    public float pickupDistance; // Set the distance within which you can pick up the gun

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            PickupGun();
        }
    }

    void PickupGun()
    {
        // Cast a ray forward from the player's position
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        // If the ray hits a GameObject within the pickup distance
        if (Physics.Raycast(ray, out hit, pickupDistance))
        {
            // If the hit GameObject has the tag "Gun"
            if (hit.transform.CompareTag("Gun"))
            {
                // Pick up the gun (you can replace this with your own logic)
                Debug.Log("Picked up the gun!");
                Destroy(hit.transform.gameObject); // This line is just for demonstration, replace it with your own logic
            }
        }
    }
}