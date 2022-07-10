using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combination : MonoBehaviour
{
    //get all of the pins

    [SerializeField] GameObject[] pins;
    //List<ClickToMove> pins = new List<ClickToMove>();
    int[,] affectedPins = new int[7, 7];
    void Start()
    {
        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                affectedPins[i, j] = -1;
            }
        }
        //position in array defines pins that will be moved
        affectedPins[0, 0] = 0;
        affectedPins[0, 2] = 1;
        affectedPins[2, 4] = 2;
        affectedPins[0, 1] = 3;
        affectedPins[4, 4] = 4;
        affectedPins[4, 5] = 5;
        affectedPins[6, 6] = 6;
    }

    public void GetArrayPoss(string number, out int pos1, out int pos2)
    {
        int v1 = 0, v2 = 0;
        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                if(affectedPins[i, j].ToString() == number)
                {
                    v1 = i;
                    v2 = j;
                }
            }
        }
        pos1 = v1;
        pos2 = v2;
    }

    public GameObject[] GetListPins()
    {
        return pins;
    }
}
