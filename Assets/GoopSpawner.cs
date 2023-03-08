using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoopSpawner : MonoBehaviour
{
    public GameObject GoopParticle;
    public int numParticles = 100;
    private int currentParticles = 0;
    public Transform spawnTransform;
    private bool isTriggered = false;

    // Update is called once per frame
    void Update()
    {
        if (isTriggered)
            if (currentParticles < numParticles)
            {
                // spawnTransform.position = new Vector3(Random.Range(0f, 0.5f), 0, 0);
                GameObject newObject = Instantiate(GoopParticle, spawnTransform);
                currentParticles += 1;
            }
    }

    public void TriggerFlow()
    {
        isTriggered = true;
    }
}
