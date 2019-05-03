using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_Comtrol_Script : MonoBehaviour
{
    // Start is called before the first frame update
    public Material mat1;
    public Material mat2;
    void Start()
    {
        int nightmode = PlayerPrefs.GetInt("night_mode",0);
        Debug.Log("skjknksjknskjn  "+nightmode);
        if(nightmode==1)
        {
            gameObject.GetComponent<Light>().intensity = 0;
            RenderSettings.skybox = mat1;
        }
        else
        {
            gameObject.GetComponent<Light>().intensity = 1;
            RenderSettings.skybox = mat2;
        }
       

    }
}
