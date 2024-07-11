using UnityEngine;

public class Watermelon : MonoBehaviour
{
    [Header("Parametrs")]
    private AudioSource audioWatermelon;
    public AudioSource[] soundsEffects;
    public float delayDestroy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            audioWatermelon = soundsEffects[Random.Range(0, soundsEffects.Length - 1)];
            GameManager.GameRecord++;
            audioWatermelon.Play();
            Destroy(gameObject, delayDestroy);
        }
    }
}