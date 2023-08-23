using Assets;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D characterBody;
    private SpriteRenderer sprite;
    private Animator anim;

    private float moveSpeed = 7f;
    private float jumpForce = 14f;

    // Start is called before the first frame update
    void Start()
    {
        characterBody = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float dirX = Input.GetAxisRaw(MovingConstants.Horizontal);
        characterBody.velocity = new Vector2(dirX * moveSpeed, characterBody.velocity.y);

        if (Input.GetButtonDown(MovingConstants.Jump))
        {
            characterBody.velocity = new Vector2(characterBody.velocity.x, jumpForce);
        }

        UpdateAnimationState(dirX);
    }


    private void UpdateAnimationState(float dirX)
    {
        if (dirX > 0f)
        {
            anim.SetBool(MovingConstants.Running, true);
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            anim.SetBool(MovingConstants.Running, true);
            sprite.flipX = true;
        }
        else
        {
            anim.SetBool(MovingConstants.Running, false);
        }
    }
}

