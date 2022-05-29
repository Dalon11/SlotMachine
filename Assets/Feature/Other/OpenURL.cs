using UnityEngine;

public class OpenURL : MonoBehaviour
{
    public void ButtonOpenURL(string url) 
    {
        Application.OpenURL(url);
    }

}
