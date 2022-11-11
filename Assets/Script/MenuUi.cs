using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuUi : MonoBehaviour
{
    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
             Application.Quit();
#endif
    }


    public void Chroma()
    {
        SceneManager.LoadScene("ChromaKey");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

}
