using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combination : MonoBehaviour
{
    //get all of the pins
    List<ClickToMove> pins = new List<ClickToMove>();
    int[,] affectedPins = new int[7, 7];
    void Start()
    {
        foreach (ClickToMove pin in gameObject.GetComponentsInChildren<ClickToMove>())
        {
            pins.Add(pin);
        }
    }
}
