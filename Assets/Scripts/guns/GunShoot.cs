using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShoot : MonoBehaviour
{
    public Transform shootPoint;
    public GameObject bullet;

    public void Shoot()
    {
        Instantiate(bullet, shootPoint.position, shootPoint.rotation);
    }
}
