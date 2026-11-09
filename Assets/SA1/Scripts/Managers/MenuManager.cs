using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    //different scenes
    public void MaiMenu()
    {
        Debug.Log("Going to Menu");
        SceneManager.LoadScene("MainMenuSC");
    }
    public void StartGame()
    {
        Debug.Log("Starting Game");
        SceneManager.LoadScene("GameSC");
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}