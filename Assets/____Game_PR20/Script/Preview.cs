using UnityEngine.SceneManagement;
using UnityEngine;

public class Preview : MonoBehaviour
{
   public void skip()
    {
        SceneManager.LoadScene(1);
    }
}
