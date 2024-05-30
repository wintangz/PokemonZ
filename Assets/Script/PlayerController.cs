using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer sr;
    public float moveSpeed = 1f;
    public float collisionOffset = 0.05f;
    public ContactFilter2D movementFilter;

    // New Input (Before movementInput updated)
    float xAxis;
    float yAxis;

    Vector2 movementInput;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        xAxis = Input.GetAxisRaw("Horizontal");
        yAxis = Input.GetAxisRaw("Vertical");

        OnMove(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        UpdateAnimation();

        if (movementInput != Vector2.zero)
        {
            bool tryMove = TryMove(movementInput);
            if (!tryMove)
            {
                tryMove = TryMove(new Vector2(movementInput.x, 0));
                if (!tryMove)
                {
                    tryMove = TryMove(new Vector2(0, movementInput.y));
                }
            }
        }
    }

    private bool TryMove(Vector2 direction)
    {
        if (movementInput == Vector2.zero)
        {
            return false;
        }

        int count = rb.Cast(
        direction,
        movementFilter,
        castCollisions,
        moveSpeed * Time.fixedDeltaTime + collisionOffset
        );

        if (count == 0)
        {
            rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
            return true;
        }

        return false;
    }

    void OnMove(float xAxis, float yAxis)
    {
        movementInput = new Vector2(xAxis, yAxis);
    }

    void UpdateAnimation()
    {
        if (movementInput != Vector2.zero)
        {
            if (Mathf.Abs(movementInput.y) == 0)
            {
                if (movementInput.x > 0) // go right
                {
                    animator.SetInteger("isMoving", 4);
                }
                else // go left
                {
                    animator.SetInteger("isMoving", 3);
                }
            }
            else
            {
                if (movementInput.y > 0) // go up
                {
                    animator.SetInteger("isMoving", 1);
                }
                else // go down
                {
                    animator.SetInteger("isMoving", 2);
                }
            }
        }
        else
        {
            animator.SetInteger("isMoving", 0);
        }
    }
}
