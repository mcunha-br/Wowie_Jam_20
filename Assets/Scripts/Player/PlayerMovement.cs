using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

  public float speed;

  public Rigidbody2D rb;

  public Animator animator;

  public float jumpHeight;

  public bool isJumping = false;

  void Start()
  {
  }

  void Update()
  {
    var horizontal = Input.GetAxisRaw("Horizontal");

    if (horizontal > 0)
    {
      transform.localRotation = Quaternion.Euler(0f, 180f, 0f);
      animator.SetInteger("AnimState", 2);
    }
    else if (horizontal < 0)
    {
      transform.localRotation = Quaternion.identity;
      animator.SetInteger("AnimState", 2);
    }
    else if (horizontal == 0)
    {
      animator.SetInteger("AnimState", 0);
    }

    Move(horizontal);

    if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
    {
      Jump();
    }
  }

  void Move(float horizontal)
  {
    var movement = new Vector2(horizontal * speed, rb.velocity.y);
    rb.velocity = movement;
  }

  public void Jump()
  {
    rb.velocity = Vector2.zero;
    isJumping = true;
    rb.AddForce(Vector2.up * jumpHeight);
    animator.SetBool("Grounded", false);
    animator.SetFloat("AirSpeed", -1f);
  }

  public void Grounded()
  {
    isJumping = false;
    animator.SetBool("Grounded", true);
    animator.SetFloat("AirSpeed", 0f);
  }
}
