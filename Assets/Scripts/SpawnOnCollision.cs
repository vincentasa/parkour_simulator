using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnCollision : MonoBehaviour
{
    public GameObject prefab; // The gameObject to spawn
    public Transform[] spawnLocations; // The locations to spawn the gameObject
    private bool hasActivated = false; // Variable to check if the script has been activated

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && !hasActivated)
        {
            foreach (Transform spawnLocation in spawnLocations)
            {
                Instantiate(prefab, spawnLocation.position, spawnLocation.rotation);
            }
            hasActivated = true; // Set the variable to true after activation
        }
    }
}
