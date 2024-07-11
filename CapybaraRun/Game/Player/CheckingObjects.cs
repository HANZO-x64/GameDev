using UnityEngine;

public class CheckingObjects : MonoBehaviour
{
    [Header("Check objects before jumping")]
    public bool checkingObject = true;
    [Tooltip("Types of directions:\n0.Null\n1.Up\n2.Down\n3.Left\n4.Right")]
    [Range(0, 4)] public int direction = 0;

    public Transform ObjectCheck;
    public float checkRadius = 0.2f;
    public LayerMask Objects;

    private void Update()
    {
        Checking();
        switch(direction)
        {
            case 1:
                PlayerControllerPc.jumpingStatusUp = checkingObject;
                break;
            case 2:
                PlayerControllerPc.jumpingStatusDown = checkingObject;
                break;
            case 3:
                PlayerControllerPc.jumpingStatusLeft = checkingObject;
                break;
            case 4:
                PlayerControllerPc.jumpingStatusRight = checkingObject;
                break;
            case 0:
            default:
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "NoJump")
        {
            checkingObject = true;
        }
        else
        {
            checkingObject = false;
        }
    }

    private void Checking()
    {
        checkingObject = Physics2D.OverlapCircle(ObjectCheck.position, checkRadius, Objects);
    }
}
