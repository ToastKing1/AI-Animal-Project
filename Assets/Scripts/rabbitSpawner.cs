using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rabbitSpawner : MonoBehaviour
{

    public float timer;
    public GameObject rabbit;
    public float timeLimit;
    public float rabbitLimit = 5;
    public float rabbitAmount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += 1 * Time.deltaTime;

        if (timer > timeLimit && rabbitAmount <= rabbitLimit)
        {
            rabbitAmount += 1;
            Instantiate(rabbit);
            timer = 0;
        }
    }
}
