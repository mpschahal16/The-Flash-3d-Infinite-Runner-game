
using UnityEngine;
using UnityEngine.SceneManagement;


public class Character_Sel_menu : MonoBehaviour
{
    public GameObject character_select_m;
    public GameObject main_menu;
    public GameObject flash;
    public GameObject girl;
    public void SelectCharacter()
    {
        if(flash.active)
        {
            PlayerPrefs.SetInt("Player_no", 0);
        }
        if(girl.active)
        {
            PlayerPrefs.SetInt("Player_no", 1);
        }
        BackGame();
    }
    public void BackGame()
    {
        main_menu.SetActive(true);
        character_select_m.SetActive(false);
        girl.SetActive(false);
        flash.SetActive(false);
    }
    public void ExitGame()
    {
        Debug.Log("Quit_game");
        Application.Quit();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow)||Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (flash.active)
            {
                flash.active = false;
                girl.active = true;
            }
            else
            {
                girl.active = false;
                flash.active = true;
            }
        }
    }

}
