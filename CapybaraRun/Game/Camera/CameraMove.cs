using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [Header("Parameters")]
    [Range(0, 25)][SerializeField] private float speedCamera = 2.5f;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private string playerTag;

    private void Start()
    {
        if (this.playerTransform == null)
        {
            if (this.playerTag == "")
            {
                this.playerTag = "Player";
            }
            this.playerTransform = GameObject.FindGameObjectWithTag(this.playerTag).transform;

            this.transform.position = new Vector3()
            {
                x = this.playerTransform.position.x + 10f,
                y = 0,
                z = -10
            };
        }
    }

    private void FixedUpdate()
    {

        // Move and bust:
        /*transform.Translate(Vector3.right * speedCamera * Time.deltaTime);*/
        switch (GameManager.GameRecord)
        {
            case 15:
                speedCamera = 2.5f;
                break;
            case 25:
                speedCamera = 5f;        
                break;
            case 80:
                speedCamera = 6.5f;
                break;
            case 250:
                speedCamera = 8f;
                break;
            case 500:
                speedCamera = 10f;
                break;
        }

        if (this.playerTransform)
        {
            Vector3 target = new Vector3()
            {
                x = this.playerTransform.position.x + 10f,
                y = 0,
                z = -10
            };
            Vector3 pos = Vector3.Lerp(this.transform.position, target, this.speedCamera * Time.deltaTime);
            this.transform.position = pos;
        }


    }
}
