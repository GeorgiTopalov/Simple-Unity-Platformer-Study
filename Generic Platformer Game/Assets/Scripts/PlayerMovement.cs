using Assets;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D characterBody;
    private BoxCollider2D collider;
    private SpriteRenderer sprite;
    private Animator anim;

    private float moveSpeed = 7f;
    private float jumpForce = 14f;

    [SerializeField] private LayerMask jumpableGround;

    // Start is called before the first frame update
    void Start()
    {
        characterBody = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float dirX = Input.GetAxisRaw("Horizontal");
        characterBody.velocity = new Vector2(dirX * moveSpeed, characterBody.velocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            characterBody.velocity = new Vector2(characterBody.velocity.x, jumpForce);
        }
        

        UpdateAnimationState(dirX);
    }


    private void UpdateAnimationState(float dirX)
    {
        MovementState state;

        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;

            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;

        }

        if(characterBody.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (characterBody.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("movementState", (int)state);
    }

    private bool isGrounded()
    {
       return Physics2D.BoxCast(collider.bounds.center, collider.bounds.size, 0f, Vector2.down, .1f, jumpableGround);

    }
}

