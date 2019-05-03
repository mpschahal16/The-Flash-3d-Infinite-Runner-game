using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_Script : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource coin;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, 90 * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.name.Contains("Player"))
        {
            coin.Play();
            other.GetComponent<Player_Controller>().noOfcoin++;
            Destroy(gameObject);
        }
    }
}
