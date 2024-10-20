using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private KeyCode up = KeyCode.W;
    [SerializeField] private KeyCode down = KeyCode.S;
    [SerializeField] private KeyCode left = KeyCode.A;
    [SerializeField] private KeyCode right = KeyCode.D;

    [SerializeField] private float movementSpeed = 10f;
    private Rigidbody2D rb;
    private Vector2 velocity;

    public Animator animator;

    public bool canMove;

    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
        rb = GetComponent<Rigidbody2D>();
        velocity = Vector2.zero;

        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        FlipPlayer();
    }

    private void Movement()
    {
        velocity = Vector2.zero;

        if(canMove)
        {
            if (Input.GetKey(up))
            {
                velocity.y = 1;
            }
            if (Input.GetKey(down))
            {
                velocity.y = -1;
            }
            if (Input.GetKey(right))
            {
                velocity.x = 1;
            }
            if (Input.GetKey(left))
            {
                velocity.x = -1;
            }

            rb.velocity = velocity.normalized * movementSpeed;

            
        }
        animator.SetFloat("MovSpeed", Mathf.Abs(rb.velocity.magnitude));
    }

    private void FlipPlayer()
    {
        if (rb.velocity.x < 0 && transform.right.x > 0)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);

        }
        else if (rb.velocity.x > 0 && transform.right.x < 0)
        {
            transform.rotation = Quaternion.identity;

        }

        // https://answers.unity.com/questions/640162/detect-mouse-in-right-side-or-left-side-for-player.html
        //if (Input.GetMouseButton(1))
        //{
        //    var playerScreenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        //    if (Input.mousePosition.x < playerScreenPoint.x)
        //        transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        //    else
        //        transform.rotation = Quaternion.identity;
        //}
        //Debug.Log($"Input.mousePosition: {(Input.mousePosition.x - 615) / 2},{(Input.mousePosition.y - 360) / 2}");
        //Debug.Log($"gameObject.transform.position: {gameObject.transform.position}");
    }
}
