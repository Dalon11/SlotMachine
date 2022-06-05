using UnityEngine;

public class OpenURL : MonoBehaviour
{
    [Header("—сылка.")]
    [SerializeField] private string url;

    public void ButtonOpenURL() 
    {
        Application.OpenURL(url);
    }

}
