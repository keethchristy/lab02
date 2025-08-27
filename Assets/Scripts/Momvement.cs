using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public float movespeed = 5f;
    [SerializeField] public float jumpForce = 5f;

    private bool isGrounded;

    public Rigidbody2D rb;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        float horizontalmovement = Input.GetAxis("Horizontal");
        float verticalmovement = Input.GetAxis("Vertical");

        UnityEngine.Vector2 movement = new UnityEngine.Vector2(horizontalmovement, 0);

        transform.Translate(movement * movespeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(UnityEngine.Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
