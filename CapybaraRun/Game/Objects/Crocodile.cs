using UnityEngine;

public class Crocodile : MonoBehaviour
{
    [Header("Settings of crocodile")]
    public AudioSource throwingSound;
    public Animator animatorCrocodile;
    public float delaeyIdolAnim;

    private void OnTriggerEnter2D(Collider2D collision)
    {
            if (collision.gameObject.tag == "Player")
            {
                animatorCrocodile.SetBool("isThrow", true);
                throwingSound.Play();
                Invoke("DelayDrop", delaeyIdolAnim);
            }
    }

    private void DelayDrop()
    {
        animatorCrocodile.SetBool("isThrow", false);
    }
    
}
