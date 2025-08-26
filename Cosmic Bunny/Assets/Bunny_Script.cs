using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bunny_Script : MonoBehaviour
{
    private Rigidbody2D rb;
    Vector3 mouseposition;
    Vector2 position = Vector2.zero;
    public float moveSpeed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
        position = Vector2.Lerp(transform.position, mouseposition, moveSpeed);
        rb.MovePosition(new Vector2(position.x, 0));
    }
}
