using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoopSpawner : MonoBehaviour
{
    public GameObject GoopParticle;
    public float increaseFactor = 0;
    private float currentSizeIncrease = 0;
    public float maxIncrease = 0;
    private bool isTriggered = false;

    private float spawnTimer;
    [SerializeField] private float spawnTime = .3f;

    // Update is called once per frame
    void Update()
    {
        if (isTriggered)
        {
            spawnTimer += Time.deltaTime;
            if (spawnTimer > spawnTime)
            {
                spawnTimer = 0;
                GoopParticle.GetComponent<GoopParticle>().setIncreaseFactor(currentSizeIncrease);
                GameObject newObject = Instantiate(GoopParticle, this.transform.position, this.transform.rotation);
                newObject.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-10, 10), 10);
                if (currentSizeIncrease < maxIncrease)
                {
                    currentSizeIncrease += increaseFactor;
                }
            }
        }
    }

    public void TriggerFlow()
    {
        isTriggered = true;
    }

    public void StopFlow()
    {
        isTriggered = false;
    }

    // public void spawnParticle(Transform transform)
    // {
    //     GameObject newObject = Instantiate(GoopParticle, this.transform.position, this.transform.rotation);
    //     newObject.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-10, 10), -5);
    // }
}
