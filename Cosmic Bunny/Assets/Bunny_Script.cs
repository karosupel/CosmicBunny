using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bunny_Script : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject Ground;

    Vector3 mouseposition;
    Vector2 position = Vector2.zero;

    public float moveSpeed = 0.1f;
    private Animator animator;
    public float jumpForce = 10;
    public bool canAdd = true;
    public float maxSpeed;
    public float TimeFalling;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        mouseposition = Input.mousePosition;
        mouseposition = Camera.main.ScreenToWorldPoint(mouseposition);

        //Movement ala Doodle Jump:

        Vector2 target = new Vector2(mouseposition.x, rb.position.y);

        float targetX = mouseposition.x;
        float smoothX = Mathf.Lerp(rb.position.x, targetX, moveSpeed);

        rb.velocity = new Vector2(
            (smoothX - rb.position.x) / Time.fixedDeltaTime,
            rb.velocity.y
        );

        if (rb.velocity.y > maxSpeed)
        {
            rb.velocity = new Vector2(rb.velocity.x, maxSpeed);
        }

        if (rb.velocity.y < 0)
        {
            TimeFalling += Time.fixedDeltaTime;
        }
        if (rb.velocity.y >= 0)
        {
            TimeFalling = 0;
        }
        if (TimeFalling > 0.7)
        {
            Debug.Log("You Died!");
            Destroy(Ground);
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (canAdd == true)
        {
            canAdd = false;
            StartCoroutine(AddForce());
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        animator.SetBool("GroundTouched", true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        animator.SetBool("GroundTouched", false); 
    }

    public IEnumerator AddForce()
    {
        rb.AddForce(Vector2.up * jumpForce);
        yield return new WaitForSeconds(0.2f);
        canAdd = true;
    }
}
