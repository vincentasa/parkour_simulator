using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipScript : MonoBehaviour
{
    public Transform playerTransform;
    public GameObject Gun;
    public Camera playerCamera;
    public float range;
    public GunShoot gunshoot;
    public KeyCode shootKey;
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
        if (Input.GetKeyDown(shootKey) && gunshoot != null)
        {
            gunshoot.Shoot();
        }

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
       
        if (isEquipped)
        {
            Gun.transform.localPosition = Vector3.zero;
            Gun.transform.localRotation = Quaternion.identity;
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
        gunshoot = null;
        Gun.transform.SetParent(null);
        Gun.GetComponent<Rigidbody>().isKinematic = false;
        Gun.GetComponent<BoxCollider>().enabled = true;
 
    }

    void EquipObject()
    {
        gunshoot = Gun.GetComponent<GunShoot>();
        Debug.Log("Equipping object");
        Gun.GetComponent<Rigidbody>().isKinematic = true;
        Gun.GetComponent<BoxCollider>().enabled = false;
        Gun.transform.SetParent(playerTransform);
        Gun.transform.localPosition = new Vector3(0f, 0f, 0f); // Set local position to (0, 0, 0)
        Gun.transform.localPosition = Vector3.zero;
        Gun.transform.localEulerAngles = new Vector3(270,0,0);
    }
}
