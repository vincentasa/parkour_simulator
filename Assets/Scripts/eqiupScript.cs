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

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(camera.transform.position, camera.transform.localPosition, out hit, range))
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
        Gun.transform.SetParent(null);
        Gun.GetComponent<Rigidbody>().isKinematic = false;
    }

    void EquipObject()
    {
        Gun.GetComponent<Rigidbody>().isKinematic = true;
        Gun.transform.SetParent(PlayerTransform);
        Gun.transform.localPosition = Vector3.zero;
        Gun.transform.localRotation = Quaternion.identity;
    }
}
