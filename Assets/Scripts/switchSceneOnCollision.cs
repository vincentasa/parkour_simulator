using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class switchSceneOnCollision : MonoBehaviour
{
    public string switchSceneName;

    public void OnCollisionEnter(Collision collision)
    {
        SceneManager.LoadScene(switchSceneName);
    }
}
