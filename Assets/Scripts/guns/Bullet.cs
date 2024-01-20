using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;

    private void Start()
    {
        Destroy(gameObject, 2f);
    }


    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<Health>().Damage();
        }
        Destroy(gameObject);
    }

}