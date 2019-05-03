using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Audio;
public class Settings_menu_Script : MonoBehaviour
{
    public Toggle devo1Toggle;

    public Slider uisound_slider;

    public AudioMixer uiauiomixture;

    public Slider gamesound_slider;

    public AudioMixer gameauiomixture;

    bool onlyload=false;


  
    public void check_mod()
    {
        onlyload = true;
        int nightmode = PlayerPrefs.GetInt("night_mode", 0);
        if (nightmode == 0)
        {
            devo1Toggle.isOn = false;
        }
        else
        {
            devo1Toggle.isOn = true;
        }
        Debug.Log("value loaded :" + devo1Toggle.isOn);
        fixsliders();
    }



    public void change_mod()
    {
        /*if (onlyload)
        {
            onlyload = false;
            Debug.Log("only_load :" + onlyload);
            return;
        }*/


        if (!devo1Toggle.isOn)
        {
            PlayerPrefs.SetInt("night_mode", 0);
            Debug.Log("Night mode active");
            PlayerPrefs.Save();
        }
        else
        {
            PlayerPrefs.SetInt("night_mode", 1);
            Debug.Log("Night mode deactive");
            PlayerPrefs.Save();
        }


    }


    public void onUISoundChange()
    {
        float slidervalue = uisound_slider.value;

        uiauiomixture.SetFloat("UI_Volume", slidervalue);
        PlayerPrefs.SetFloat("UI_Volume", slidervalue);
        PlayerPrefs.Save();

    }

    public void onmusicSoundChange()
    {
        float slidervalue = gamesound_slider.value;

        gameauiomixture.SetFloat("Game_Volume", slidervalue);
        PlayerPrefs.SetFloat("Game_Volume", slidervalue);
        PlayerPrefs.Save();

    }

    void fixsliders()
    {
        float slidervalue = PlayerPrefs.GetFloat("UI_Volume", -16);

        uisound_slider.value = slidervalue;

        slidervalue = PlayerPrefs.GetFloat("Game_Volume", -16);

        gamesound_slider.value = slidervalue;

    }


}
