using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoopParticle : MonoBehaviour
{
    [SerializeField] private float timeInstantiated;
    private float currTime;

    private void Start()
    {
        currTime = timeInstantiated;
    }

    // Update is called once per frame
    void Update()
    {
        currTime -= Time.deltaTime;
        if (currTime <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
