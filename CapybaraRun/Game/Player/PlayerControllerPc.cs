using UnityEngine;

public class PlayerControllerPc : MonoBehaviour
{
    [Header("Player controller")]
    public float XIncrement;
    public float YIncrement;
    public Transform GroundCheck;
    public bool onGround = false;
    public float checkRadius = 0.5f;
    public LayerMask Ground;
    public Transform fatherObject;

    [Header("Animation")]
    public Animator animator;

    [Header("Player death")]
    [SerializeField] private float delayDeath;

    [Header("Check objects before jumping")]
    public static bool jumpingStatusRight;
    public static bool jumpingStatusLeft;
    public static bool jumpingStatusUp;
    public static bool jumpingStatusDown;

    [Header("SoundEffects")]
    private AudioSource soundJump;
    public AudioSource[] SoundsJumpArr;


    private void Start()
    {
        // anim
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        CheckingGround();
        PlayerJump();
        PlayerController();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Player controller:
        if (collision.gameObject.tag != "Ground")
        {
            // is Jump
            onGround = false;
        }
        else
        {
            // idol anim
            onGround = true;
        }
    }

    private void CheckingGround()
    {
        onGround = Physics2D.OverlapCircle(GroundCheck.position, checkRadius, Ground);
    }

    private void PlayerJump()
    {
        // --Update
        // Face ->
        if (Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("isJumpRight", false);
        }

        // Face <-
        if (Input.GetKeyUp(KeyCode.A))
        {
            animator.SetBool("isJumpLeft", false);
        }
    }

    private void PlayerController()
    {
        soundJump = SoundsJumpArr[Random.Range(0, SoundsJumpArr.Length - 1)];
        
        // Left - Right
        if (Input.GetKeyDown(KeyCode.A) && onGround && (jumpingStatusLeft == false))
        {
            animator.SetBool("isJumpLeft", true);
            transform.position = new Vector2(transform.position.x - XIncrement, transform.position.y + YIncrement / 3);
            PlayerJump();
        }
        else if (Input.GetKeyDown(KeyCode.D) && onGround && (jumpingStatusRight == false))
        {
            animator.SetBool("isJumpRight", true);
            transform.position = new Vector2(transform.position.x + XIncrement, transform.position.y + YIncrement / 3);
            PlayerJump();
        }

        // Up - Down
        if (Input.GetKeyDown(KeyCode.W) && onGround && (jumpingStatusUp == false))
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + YIncrement);
        }
        else if (Input.GetKeyDown(KeyCode.S) && onGround && (jumpingStatusDown == false))
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - YIncrement);
        }
    }
}