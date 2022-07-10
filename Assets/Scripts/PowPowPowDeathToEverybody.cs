using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowPowPowDeathToEverybody : MonoBehaviour
{
    public void KillEveryone()
    {
        SubtitleController subtitleController = FindObjectOfType(typeof(SubtitleController)) as SubtitleController;
        subtitleController.ChoiceMade();

        Crowbar crowbar = FindObjectOfType(typeof(Crowbar)) as Crowbar;
        crowbar.DisableChoiceScreen();
    }
}
