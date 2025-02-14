using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public bool night = false;
    public Light directLight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DayNight();
        }

        
    }

    public void DayNight()
    {
        night = !night;
        if (night)
        {
            //directLight.color = new Vector4(255, 244, 214, 255);
            directLight.color = Color.blue;
        }
        else
        {
            //directLight.color = new Vector4(108, 95, 159, 255);
            directLight.color = Color.white;
        }
    }
}
