using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eqiupScript : MonoBehaviour
{
    public Transform PlayerTransform;
    public GameObject Gun;
    public Camera camera;
    public float range;
    public float open;
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
        if (Input.GetKeyDown("f"))
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

    void Shoot ()
    {
        RaycastHit hit;
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                EquipObject();
            }
        }
    }

    void UnequipObject()
    {
        PlayerTransform.DetachChildren();
        Gun.transform.eulerAngles = new Vector3(Gun.transform.eulerAngles.x, Gun.transform.eulerAngles.y, Gun.transform.eulerAngles.z - 45);
        Gun.GetComponent<Rigidbody>().isKinematic = false;
    }

    void EquipObject()
    {
        Gun.GetComponent<Rigidbody>().isKinematic = true;
        Gun.transform.position = PlayerTransform.transform.position;
        Gun.transform.rotation = PlayerTransform.transform.rotation;
        Gun.transform.SetParent(PlayerTransform);
    }
}
