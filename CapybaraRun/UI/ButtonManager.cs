using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public int Scenenumber;
    public string linkTelegramChannel;

    // Load scene
    public void TransitionToScene(int Scenenumber)
    {
        SceneManager.LoadScene(Scenenumber);
    }

    // URL link (TG & DS)
    public void TransitionToTelegramChannel(string linkTelegramChannel)
    {
        Application.OpenURL(linkTelegramChannel);
    }

    // Exit
    public void ExitTheGame()
    {
        Application.Quit();
    }
}