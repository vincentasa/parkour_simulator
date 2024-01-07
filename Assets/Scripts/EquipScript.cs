using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipScript : MonoBehaviour
{
    public Transform playerTransform;
    public GameObject Gun;
    public Camera playerCamera;
    public float range;
    private bool isEquipped;

    // Start is called before the first frame update
    void Start()
    {
        Gun.GetComponent<Rigidbody>().isKinematic = true;
        isEquipped = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (isEquipped)
            {
                UnequipObject();
            }
            else
            {
                EquipObject();
                Shoot();
            }
            isEquipped = !isEquipped;
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                // You might want to do something specific when hitting a target
            }
        }
    }

    void UnequipObject()
    {
        Debug.Log("Unequipping object");
        Gun.transform.SetParent(null);
        Gun.GetComponent<Rigidbody>().isKinematic = false;
    }

    void EquipObject()
    {
        Debug.Log("Equipping object");
        Gun.GetComponent<Rigidbody>().isKinematic = true;
        Gun.transform.SetParent(playerTransform);
        Gun.transform.localPosition = new Vector3(0f, 0f, 0f); // Set local position to (0, 0, 0)
        Gun.transform.localPosition = Vector3.zero;
        Gun.transform.localRotation = Quaternion.identity;
    }
}
