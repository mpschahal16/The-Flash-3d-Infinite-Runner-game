using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_light_Script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int nightmode = PlayerPrefs.GetInt("night_mode", 0);
        if(nightmode!=1)
        {
            Destroy(gameObject);
        }

    }

  
}
