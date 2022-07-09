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
    }
    public void DestroyObject()
    { 
        GameObject particlesObject = Instantiate(destructionParticles,transform.position,Quaternion.identity) as GameObject;
        particlesObject.GetComponent<ParticleSystem>().Play();
        Destroy(gameObject);
    }
}
