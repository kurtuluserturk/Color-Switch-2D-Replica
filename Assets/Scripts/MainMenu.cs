using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{                     
    public void PlayGame()
    {                 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1 );     //Sondaki +1 yeni sahneye yani yeni level' a geçirir.
    }
    public void QuitGame()
    {
        Application.Quit();   //Unity editörde çalışmaz.        
    }
}
