using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public LayerMask encounterableLayer;

    public event Action OnEncountered;

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
    private Vector2 lastInput;

    // Start is called before the first frame update
    void Start()
    {
        lastInput = Vector2.zero;
    }

    // Update is called once per frame
    public void HandleUpdate()
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

        CheckForEncounters();
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
            if (movementInput.x != 0) movementInput.y = 0;

            // Track the last input direction
            if (Mathf.Abs(movementInput.y) > Mathf.Abs(movementInput.x))
            {
                lastInput = new Vector2(0, movementInput.y);
            }
            else
            {
                lastInput = new Vector2(movementInput.x, 0);
            }

            // Set animation based on the last input direction
            if (Mathf.Abs(lastInput.y) == 0)
            {
                if (lastInput.x > 0) // go right
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
                if (lastInput.y > 0) // go up
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

    void CheckForEncounters()
    {
        if (Physics2D.OverlapCircle(transform.position, 0.04f, encounterableLayer) != null)
        {
            Debug.Log("Entered Long grass");
            if (UnityEngine.Random.Range(1, 5000) == 1)
            {
                animator.SetInteger("isMoving", 0);
                Debug.Log("Encountered");
                // OnEncountered();
            }
        }
    }
}
