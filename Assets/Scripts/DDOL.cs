using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDOL : MonoBehaviour
{
    public GameObject balls;
    void Start()
    {
        DontDestroyOnLoad(balls);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
