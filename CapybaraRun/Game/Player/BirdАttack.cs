using UnityEngine;

public class BirdАttack: MonoBehaviour
{
    [Header("Parameters player")]
    public float idle_lim = 15.0f; // допустимый лимит в секундах
    private float last_ui = 0.0f;
    [SerializeField] private float delayBeforeResetPlayer;
    [SerializeField] private float delayBeforeDefeatScene;
    private bool DefeatFromPlayerInaction;
    public GameObject playerObj;

    [Header("Parameters bird")]
    public GameObject BirdPref;

    private void Start()
    {
        DefeatFromPlayerInaction = false;
    }

    void FixedUpdate()
    {
        if ((Input.anyKeyDown)) 
        {
            last_ui = Time.timeSinceLevelLoad;
        }
        if (((Time.timeSinceLevelLoad - last_ui) > idle_lim) && (DefeatFromPlayerInaction == false))
        {
            BirdAttack();
            DefeatFromPlayerInaction = true;
        }
    }

    private void BirdAttack()
    {
        Instantiate(BirdPref);
        BirdPref.SetActive(true);
        PlayerControllerPc scriptController = gameObject.GetComponent<PlayerControllerPc>();
        scriptController.enabled = false;
        // a crutch of delays. Fixed in the future: 
        Invoke("ResetPalyerOnScene", delayBeforeResetPlayer);
    }
    private void ResetPalyerOnScene()
    {
        playerObj.SetActive(false);
        Invoke("DestroyPlayerOnScene", delayBeforeDefeatScene);
    } // a crutch 1

    private void DestroyPlayerOnScene()
    {
        Defeat.DefeatFromBird = true;
    } // a crutch 2
}
