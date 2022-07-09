using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupable : MonoBehaviour
{
    [SerializeField] string name;
    [SerializeField] ShowItem inventory;

    public void PickUp()
    {
        inventory.AddItem(name);
        Destroy(gameObject);
    }
}
