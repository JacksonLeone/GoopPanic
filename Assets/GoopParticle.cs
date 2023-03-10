using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoopParticle : MonoBehaviour
{
    public float increaseFactor = 0;
    private float maxScaleMultiplier = 4;
    private float timer = 0.25f;
    private float currTime;
    private Rigidbody2D rb;
    private CircleCollider2D cc;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        cc = this.GetComponent<CircleCollider2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.localScale.x < maxScaleMultiplier)
        {
            currTime -= Time.deltaTime;
            if (currTime < 0)
            {
                this.gameObject.transform.localScale += new Vector3(increaseFactor, increaseFactor, increaseFactor);
                currTime = timer;
            }
        }
        else
        {
            Destroy(rb);
        }
    }
}
