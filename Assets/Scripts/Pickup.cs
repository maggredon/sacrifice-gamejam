using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Pickup : MonoBehaviour
{
    public void OnPickup(InputValue value)
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.gameObject.GetComponent<Pickupable>())
            {
                hit.transform.gameObject.GetComponent<Pickupable>().PickUp();
            }
            Debug.Log("Hit: " + hit.collider.name);
        }
    }
}
