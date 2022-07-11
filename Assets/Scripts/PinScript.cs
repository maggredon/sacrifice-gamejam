using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinScript : MonoBehaviour
{
    //script for checking all of the pins
    List<ClickToMove> pins = new List<ClickToMove>();
    bool completed;
    void Start()
    {
        foreach (ClickToMove pin in gameObject.GetComponentsInChildren<ClickToMove>())
        {
            pins.Add(pin);
        }
    }

    private void Update()
    {
        Debug.Log(Unlocked());
    }

    public bool Unlocked()
    {
        completed = true;
        for (int i = 0; i < pins.Count; i++)
        {
            if (pins[i].GetInLockedPos() == true)
            {
                completed = false;
            }
        }
        return completed;
    }

}
