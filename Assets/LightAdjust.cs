using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAdjust : MonoBehaviour
{
    [SerializeField] Light worldLight;
    Color red = new Color(1, 0, 0, 1);
    Color baseColor = new Color(0, 0, 0, 1);
    // Start is called before the first frame update
    void Start()
    {
        baseColor = worldLight.color;
    }
    private bool finished = false;
    // Update is called once per frame
    void Update()
    {
        if (!finished)
        {
            if (worldLight.intensity < 100)
                worldLight.intensity += 0.002f;
            //worldLight.color = new Color(r = Mathf.Lerp(r,1,0.0008f), 0, b = Mathf.Lerp(b, 0, 0.0008f), 1f);
            if (worldLight.intensity > 3)
            {
                worldLight.color = Color.Lerp(worldLight.color, red, 0.0007f);
            }
        }
    }

    public void FadeToBlack()
    {
        worldLight.color = Color.black;
        finished = true;
    }

}
