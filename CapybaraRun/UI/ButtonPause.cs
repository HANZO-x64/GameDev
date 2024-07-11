using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ButtonPause : MonoBehaviour
{
    [Header("UI elements")]
    public GameObject ButttonPause;
    public GameObject PausePanel;
    public TMP_Text NumbersScoreInPause;

    [Header("To transition between scenes")]
    public int SceneNumbers;
    public static bool ButtonStatus;

    private void Awake()
    {
        ButtonStatus = false;
    }

    public void StartPause()
    {
        ButtonStatus = true;
        ButttonPause.SetActive(false);
        Time.timeScale = 0f;
        PausePanel.SetActive(true);
        NumbersScoreInPause.text = GameManager.GameRecord.ToString();
    }

    public void ExitFromPause()
    {
        ButtonStatus = false;
        ButttonPause.SetActive(true);
        Time.timeScale = 1f;
        PausePanel.SetActive(false);
    }

    public void ExitToMenu(int SceneNumbers)
    {
        SceneManager.LoadScene(SceneNumbers);
    }
}
