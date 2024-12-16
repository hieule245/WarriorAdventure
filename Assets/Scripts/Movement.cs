using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 6f;
    public float heightjump = 6f;
    private float movement;
    public float slipspeed;
    public bool isGroud = true;
    private SpriteRenderer sprite;
    public Rigidbody2D rd;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        movement = Input.GetAxis("Horizontal");
        Flip();
        Jump();
        Slip();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += new Vector3(movement , 0f, 0f) * Time.fixedDeltaTime * speed;
    }

    public void Flip()
    {
        if (movement < 0f)
        {
            sprite.flipX = true;
        }
        else if (movement > 0f)
        {
            sprite.flipX = false;
        }
    }
    
    public void Jump()
    {
        if(Input.GetKey(KeyCode.Space) && isGroud == true)
        {
            rd.AddForce(new Vector2(0f, heightjump), ForceMode2D.Impulse);
            isGroud = false;
        }
    }

    public void Slip()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            rd.AddForce(new Vector2(slipspeed, 0f), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if(collision.gameObject.tag == "Ground")
        {
            isGroud = true;
        }
    }
}

