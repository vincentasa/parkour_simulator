 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;

    void Start()
    {
        Destroy(gameObject, 2f);
    }


    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }


    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<Health>().Damage();
        }
    }

}