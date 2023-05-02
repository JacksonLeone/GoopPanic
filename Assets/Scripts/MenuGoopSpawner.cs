using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuGoopSpawner : MonoBehaviour
{
    private float spawnTimer;
    [SerializeField] private float spawnTime = .3f;
    public GameObject GoopParticle;
    public float horizontalForce;
    public float verticalForce;

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnTime)
        {
            spawnTimer = 0;
            // GoopParticle.GetComponent<GoopParticle>().setIncreaseFactor(currentSizeIncrease);
            GameObject newObject = Instantiate(GoopParticle, this.transform.position, this.transform.rotation);
            newObject.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-3 + horizontalForce, 3 + horizontalForce), verticalForce);
            // if (currentSizeIncrease < maxIncrease)
            // {
            //     currentSizeIncrease += increaseFactor;
            // }
        }
    }
}
