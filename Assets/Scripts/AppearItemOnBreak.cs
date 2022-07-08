using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearItemOnBreak : MonoBehaviour
{
    [SerializeField] GameObject gameObjectToAppear;
    [SerializeField] GameObject destructionParticles;

    private void OnDestroy()
    {
        if (gameObjectToAppear == true)
        {
            gameObjectToAppear.GetComponent<MeshRenderer>().enabled = true;
        }

        GameObject particlesObject = Instantiate(destructionParticles);
        particlesObject.GetComponent<ParticleSystem>().Play();
    }
}
