using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bunny_Script : MonoBehaviour
{
    private Rigidbody2D rb;
    Vector3 mouseposition;
    Vector2 position = Vector2.zero;
    public float moveSpeed = 0.1f;
    private Animator animator;
    public float jumpForce = 10;
    public bool canAdd = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //mouseposition = Input.mousePosition;
        //mouseposition = Camera.main.ScreenToWorldPoint(mouseposition);
        //position = Vector2.Lerp(transform.position, mouseposition, moveSpeed);
    }

    private void FixedUpdate()
    {
        mouseposition = Input.mousePosition;
        mouseposition = Camera.main.ScreenToWorldPoint(mouseposition);
        //position = Vector2.Lerp(transform.position, mouseposition, moveSpeed);
        transform.position = new Vector3(mouseposition.x, transform.position.y, transform.position.z);

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
