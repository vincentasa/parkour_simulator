using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float drop;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Commence (float amount) 
    {
        drop -= amount;
        if (drop <= 0f) 
        {
            Go();
        }
    }

    void Go()
    {
        Destroy(gameObject);
    }
}
