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
    bool lastTrigger = false;
    float intCap = 3, increase = 0.002f;


    [SerializeField] GameObject player;
    void Update()
    {
        if (intCap < 5)
           // player.GetComponent<MusicPlayer>().SetVersion(1);

        if (triggers[0].GetComponent<Triggered>().GetTriggered())
            {
                intCap = 5;
                lerpColor = worldLight.color;
                SubtitleController subtitleController = FindObjectOfType(typeof(SubtitleController)) as SubtitleController;
                subtitleController.EscapeCage();
                //player.GetComponent<MusicPlayer>().SetVersion(2);
            }
        if (intCap < 8)
            if (triggers[1].GetComponent<Triggered>().GetTriggered())
            {
                intCap = 8;
                lerpColor = brightRed;
                SubtitleController subtitleController = FindObjectOfType(typeof(SubtitleController)) as SubtitleController;
                subtitleController.EnterSecondRoom();
                //player.GetComponent<MusicPlayer>().SetVersion(3);
            }
        if (intCap < 14)
        {
            if (lastTrigger)
            {
                intCap = 100;
                lerpColor = darkRed;
                increase = 5;
                //player.GetComponent<MusicPlayer>().SetVersion(4);
            }
        }
        if (worldLight.intensity < intCap)
            worldLight.intensity += increase;
        if (worldLight.intensity > 3)
        {
            worldLight.color = Color.Lerp(worldLight.color, lerpColor, 0.007f);
        }
    }

    public void SetLastTrigger(bool value)
    {
        lastTrigger = value;
    }

}
