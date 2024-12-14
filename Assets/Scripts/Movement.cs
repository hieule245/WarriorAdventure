using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeReference] public float speed = 6f;
    private float movement;
    private SpriteRenderer sprite;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        movement = Input.GetAxis("Horizontal");
        Flip();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += new Vector3(movement , 0f, 0f) * Time.fixedDeltaTime * speed;
    }

    void Flip()
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
}
