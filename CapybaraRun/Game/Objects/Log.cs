using UnityEngine;

public class Log : MonoBehaviour
{
    private AudioSource creakLog;
    public AudioSource[] creakLogArray;

    private void OnCollisionEnter2D(Collision2D other)
    {
        creakLog = creakLogArray[Random.Range(0, creakLogArray.Length - 1)];
         if (other.collider.tag == "Player")
         {
            creakLog.Play();
         }
    }

}
