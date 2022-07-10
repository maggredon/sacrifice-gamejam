using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Pickup : MonoBehaviour
{
    [SerializeField] Canvas interactScreen;
    private void Update()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.gameObject.GetComponent<Pickupable>())
            {
                if (Vector3.Distance(hit.transform.position, Camera.main.transform.position) > 2f) return;
                interactScreen.enabled = true;
            }
            else
            {
                interactScreen.enabled = false;
            }
        }
    }
    public void OnPickup(InputValue value)
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.gameObject.GetComponent<Pickupable>())
            {
                if (Vector3.Distance(hit.transform.position, Camera.main.transform.position) > 2f) return;
                hit.transform.gameObject.GetComponent<Pickupable>().PickUp();
            }
        }
    }
}
