using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisingGoop : MonoBehaviour
{
    public bool TeacherMode = false;
    public float growthRate;
    private bool isRising = false;
    [SerializeField] private GameObject GoopSpawner;
    public float GoopSpawnerDelay;
    private GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isRising)
        {
            gameObject.transform.localScale += new Vector3(0f, growthRate, 0f);
            gameObject.transform.position += new Vector3(0f, growthRate / 2, 0f);
            if (GoopSpawnerDelay > 0)
            {
                GoopSpawnerDelay -= Time.deltaTime;
            }
            else
            {
                GoopSpawner.transform.position += new Vector3(0f, growthRate, 0f);
            }
        }
        if (gm.hasTreasure() && !TeacherMode)
        {
            isRising = true;
        }
    }

    public void ToggleTeacherMode(bool isOn)
    {
        TeacherMode = isOn;
    }
}
