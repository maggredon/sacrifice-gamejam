using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAdjust : MonoBehaviour
{
    [SerializeField] Light worldLight;
    Color start = new Color(0.1f, 0.1f, 0.1f, 1);
    Color brightRed = new Color(0.4f, 0, 0, 1);
    Color darkRed = new Color(0.1f, 0, 0, 1);
    Color lerpColor;
    [SerializeField] GameObject[] triggers = new GameObject[3];

    float intCap = 3, increase = 0.002f;
    void Update()
    {
        if (intCap < 5)
            if (triggers[0].GetComponent<Triggered>().GetTriggered())
            {
                intCap = 5;
                lerpColor = worldLight.color;
                SubtitleController subtitleController = FindObjectOfType(typeof(SubtitleController)) as SubtitleController;
                subtitleController.EscapeCage();
            }
        if (intCap < 8)
            if (triggers[1].GetComponent<Triggered>().GetTriggered())
            {
                intCap = 8;
                lerpColor = brightRed;
                SubtitleController subtitleController = FindObjectOfType(typeof(SubtitleController)) as SubtitleController;
                subtitleController.EnterSecondRoom();
            }
        if (intCap < 14)
        {
            if (triggers[2].GetComponent<Triggered>().GetTriggered())
            {
                intCap = 700;
                lerpColor = darkRed;
                increase = 5;
            }
        }
        if (worldLight.intensity < intCap)
            worldLight.intensity += increase;
        if (worldLight.intensity > 3)
        {
            worldLight.color = Color.Lerp(worldLight.color, lerpColor, 0.007f);
        }
    }

}
