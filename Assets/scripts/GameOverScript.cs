using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameOverScript : MonoBehaviour
{
    public void Setup(int score)
    {
        gameObject.SetActive(true);
    }

    public void RestartLevel()
    {  
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }
}
