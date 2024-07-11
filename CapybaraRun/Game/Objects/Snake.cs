using UnityEngine;

public class Snake : MonoBehaviour
{
    [Header("Settings of snake")]
    private AudioSource kickSound;
    public AudioSource[] kickSoundArray;
    public Animator animatorSnake;
    public float delaeyIdolAnim;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        kickSound = kickSoundArray[Random.Range(0, kickSoundArray.Length - 1)];
        if (collision.gameObject.tag == "Player")
        {
            animatorSnake.SetBool("isKick", true);
            kickSound.Play();
            Invoke("delayKick", delaeyIdolAnim);
        }
    }

    private void delayKick()
    {
        animatorSnake.SetBool("isKick", false);
    }
}
