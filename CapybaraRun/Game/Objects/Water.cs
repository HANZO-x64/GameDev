using UnityEngine;

public class Water : MonoBehaviour
{
    [Header("Parameters")]
    public AudioSource fallingIntoTheWater;
    public GameObject PlayerPref;
    public string PlayerTag;
    [SerializeField] private float delayMethod; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            fallingIntoTheWater.Play();
            Invoke("StatusGame", delayMethod);
        }
    }

    private void Start()
    {
        if (this.PlayerPref == null) 
        {
            if (this.PlayerTag == "")
            {
                this.PlayerTag = "Player";
            }
            this.PlayerPref = GameObject.FindGameObjectWithTag(this.PlayerTag);
        }
    }

    private void StatusGame()
    {
        PlayerPref.SetActive(false);
        Defeat.isDefeat = true;
    }
}