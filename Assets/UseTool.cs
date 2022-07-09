using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UseTool : MonoBehaviour
{
    [SerializeField] GameObject crowbar;
    [SerializeField] GameObject axe;
    public void OnUseItem(InputValue value)
    {
        if (crowbar.GetComponent<Crowbar>().enabled)
        {
            crowbar.GetComponent<Crowbar>().UseItem();
        }
        if (axe.GetComponent<Axe>().enabled)
        {
            axe.GetComponent<Axe>().UseItem();
        }
    }
}
