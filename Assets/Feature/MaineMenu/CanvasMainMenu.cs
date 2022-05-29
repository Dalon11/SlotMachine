using UnityEngine;
using UnityEngine.SceneManagement;

namespace MainMenu
{
    public class CanvasMainMenu : MonoBehaviour
    {
       public void ButtonStart()
        {
            SceneManager.LoadScene(1);  //заглушка на будущее
        }
    }
}