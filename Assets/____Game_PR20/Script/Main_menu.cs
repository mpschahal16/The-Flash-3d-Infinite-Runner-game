
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Main_menu : MonoBehaviour
{
    public GameObject character_select_m;
    public GameObject main_menu;
    public GameObject flash;
    public GameObject girl;
    public Toggle toggle;

    public AudioMixer uiauiomixture;

    public AudioMixer gameauiomixture;
    private void Start()
    {
        Debug.Log("mpsachahal16 :stasrt called");
        float val = PlayerPrefs.GetFloat("Game_Volume", -16);
        gameauiomixture.SetFloat("Game_Volume", val);
        val = PlayerPrefs.GetFloat("UI_Volume", -16);
        uiauiomixture.SetFloat("UI_Volume", val);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("base_scene");
    }
    public void SelectCharacter()
    {
        main_menu.SetActive(false);
        character_select_m.SetActive(true);
        int i=PlayerPrefs.GetInt("Player_no", 0);
        if(i==0)
        {
            flash.SetActive(true);
        }
        else
        {
            girl.SetActive(true);
        }
        
        // SceneManager.LoadScene(2);
    }
    public void ExitGame()
    {
        Debug.Log("Quit_game");
        Application.Quit();
    }

}
