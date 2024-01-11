using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform shootPoint;
    public KeyCode shootKey;
    public GameObject bullet;

    void Update()
    {
        if (Input.GetKeyDown(shootKey))
        {
            Instantiate(bullet, shootPoint.position, shootPoint.rotation);
        }
    }
}
