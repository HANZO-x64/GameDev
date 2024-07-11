using UnityEngine;

public class MusicGame : MonoBehaviour
{
    [Header("Parameters")]
    public AudioSource musicStart;
    public AudioSource musicLoop;
    public float delayBeforeLoopMusic;

    private void Start()
    {
        TurnOnStartupMusic();
    }

    private void Update()
    {
        CheckPause();
        CheckDefeat();
    }

    private void CheckPause()
    {
        if (ButtonPause.ButtonStatus == true)
        {
            musicStart.Pause();
            musicLoop.Pause();
        }
        else if (ButtonPause.ButtonStatus == false)
        {
            musicStart.UnPause();
            musicLoop.UnPause();
        }
    }

    private void CheckDefeat()
    {
        if ((Defeat.isDefeat == true) || (Defeat.DefeatFromBird == true))
        {
            musicStart.Stop();
            musicLoop.Stop();
        }
    }

    private void TurnOnStartupMusic()
    {
        musicStart.Play();
        Invoke("StartLoopMusic", delayBeforeLoopMusic);
    }

    private void StartLoopMusic()
    {
        musicLoop.Play();
    }

}