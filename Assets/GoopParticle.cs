using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoopParticle : MonoBehaviour
{
    [SerializeField] private float increaseFactor = 0;
    [SerializeField] private float growFactor = 0;

    private float maxScale = 4;
    private float timer = 0.25f;
    private float currTime;
    private Rigidbody2D rb;
    private CircleCollider2D cc;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        cc = this.GetComponent<CircleCollider2D>();
        this.gameObject.transform.localScale += new Vector3(increaseFactor, increaseFactor, increaseFactor);
    }

    public void setIncreaseFactor(float factor)
    {
        increaseFactor = factor;
    }
    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.localScale.x < maxScale)
        {
            currTime -= Time.deltaTime;
            if (currTime < 0)
            {
                currTime = timer;
                this.gameObject.transform.localScale += new Vector3(growFactor, growFactor, growFactor);
            }
        }
        // else
        // {
        //     Destroy(rb);
        // }
    }
}
