using UnityEngine;

public class OpenURL : MonoBehaviour
{
    [Header("������.")]
    [SerializeField] private string url;

    public void ButtonOpenURL() 
    {
        Application.OpenURL(url);
    }

}
