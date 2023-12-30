using System.Collections;
using UnityEngine;

public class SpawnAndMove: MonoBehaviour
{
    public GameObject objectToSpawn; // Assign your prefab in the Inspector
    public GameObject targetObject; // Assign your target GameObject in the Inspector
    public float speed = 1f;
    public float waitTime;

    void Start()
    {
        StartCoroutine(SpawnMoveAndDestroyObject());
    }

    IEnumerator SpawnMoveAndDestroyObject()
    {
        // Spawn the object at the same position as the spawning GameObject
        GameObject spawnedObject = Instantiate(objectToSpawn, transform.position, Quaternion.identity);

        // Calculate the time it will take to move based on the speed
        float journeyTime = Vector3.Distance(transform.position, targetObject.transform.position) / speed;
        float elapsedTime = 0;

        // Move the object
        while (elapsedTime < journeyTime)
        {
            spawnedObject.transform.position = Vector3.Lerp(transform.position, targetObject.transform.position, (elapsedTime / journeyTime));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the object ends up at the exact target position
        spawnedObject.transform.position = targetObject.transform.position;

        // Destroy the object
        Destroy(spawnedObject);

        yield return new WaitForSeconds(waitTime);

        StartCoroutine(SpawnMoveAndDestroyObject());

    }
}
