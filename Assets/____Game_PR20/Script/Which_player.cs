using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Which_player : MonoBehaviour
{
    public int player_no;
    // Start is called before the first frame update
    void Start()
    {
        int temp = PlayerPrefs.GetInt("Player_no", 0);
        if (temp != player_no)
        {
            Destroy(gameObject);
        }

    }

   
}
