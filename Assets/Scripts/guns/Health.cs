using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public GameObject particle;
    public int particleCount;
    public int hp;

    public void Damage()
    {
        print(":))))))))))");
        hp--;
        if (hp <= 0) Die();
    }

    public void Die()
    {
        print(":)");
        Destroy(gameObject);
        for (int i = 0; i < particleCount; i++)
        {
            var offset = Vector3.up + Random.insideUnitSphere * 2;
            Instantiate(particle, transform.position + offset, transform.rotation);
        }
    }
}