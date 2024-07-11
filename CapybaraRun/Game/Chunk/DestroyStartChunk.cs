using UnityEngine;

public class DestroyStartChunk : MonoBehaviour
{
    public GameObject StartChunkPref;

/*    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            Destroy(StartChunkPref);
        }
    }*/
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(StartChunkPref);
        }
    }
}
