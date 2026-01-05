using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuOptions : MonoBehaviour
{
    public void StartPVP()
    {
        PlayerPrefs.SetInt("botPlaying", 0);
        PlayerPrefs.Save();
        SceneManager.LoadScene("Juego");
    }
    public void StartPVE()
    {
        PlayerPrefs.SetInt("botPlaying", 1);
        PlayerPrefs.Save();
        SceneManager.LoadScene("Juego");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
