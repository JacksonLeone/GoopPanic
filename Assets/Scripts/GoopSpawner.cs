using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoopSpawner : MonoBehaviour
{
    public GameObject GoopParticle;
    private bool isTriggered = false;

    // Update is called once per frame
    void Update()
    {
        if (isTriggered)
        {
            GameObject newObject = Instantiate(GoopParticle, this.transform.position, this.transform.rotation);
            newObject.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-10, 10), -5);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            isTriggered = !isTriggered;
        }
    }

    public void TriggerFlow()
    {
        isTriggered = true;
    }
}
