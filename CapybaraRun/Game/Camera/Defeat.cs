using TMPro;
using UnityEngine;

public class Defeat : MonoBehaviour
{
    [Header("Parametrs")]
    public Animation animDefeat;
    public static bool isDefeat = false;
    public static bool DefeatFromBird = false;
    public GameObject deathPanels;
    [SerializeField] private float delayBeforeDefeatInWater;
    [SerializeField] private float delayBeforeDefeatByBird;

    [Header("Player")]
    [SerializeField] private GameObject playerObject;
    [SerializeField] private string playerTag;

    [Header("UI elements:")]
    public TMP_Text NumbersScoreInTheGameOnPanelDefeat;
    public GameObject NumbersScoreInTheGame;
    public GameObject ButtonPause;


    private void Awake()
    {
        playerObject.SetActive(true);
        RestartGame();
        CheckPlayerOnScene();
    }

    private void Update()
    {
        CheckPlayerDefeat();
    }

    private void CheckPlayerOnScene()
    {
        if (this.playerObject == null)
        {
            if (this.playerTag == "")
            {
                this.playerTag = "Player";
            }

            this.playerObject = GameObject.FindGameObjectWithTag(this.playerTag);
        }
    }

    private void CheckPlayerDefeat()
    {
        if (isDefeat)
        {
            this.playerObject.SetActive(false);
            this.ButtonPause.SetActive(false);
            this.NumbersScoreInTheGame.SetActive(false);
            NumbersScoreInTheGameOnPanelDefeat.text = GameManager.GameRecord.ToString();
            animDefeat.Play();
            Invoke("LosingGame", delayBeforeDefeatInWater);
        }
        if (DefeatFromBird)
        {
            this.playerObject.SetActive(false);
            this.ButtonPause.SetActive(false);
            this.NumbersScoreInTheGame.SetActive(false);
            NumbersScoreInTheGameOnPanelDefeat.text = GameManager.GameRecord.ToString();
            Invoke("LosingGame", delayBeforeDefeatByBird);
        }
    }

    private void LosingGame() 
    {
        playerObject.SetActive(true);
        Time.timeScale = 0f;
        deathPanels.gameObject.SetActive(true);
    }

    private void RestartGame()
    {
        Time.timeScale = 1f;
        isDefeat = false;
        DefeatFromBird = false;
        Instantiate(playerObject);
        if (playerObject == false) playerObject.SetActive(true); 
    }

}
