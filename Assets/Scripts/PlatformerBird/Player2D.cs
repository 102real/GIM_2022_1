using UnityEngine;

public class Player2D : MonoBehaviour
{
    public Sprite[] sprites;
    private int spriteIndex;
    public Rigidbody2D _rigidbody;
    public Transform firePoint;
    public GameObject bullet;
    public GameObject RemainTime;


    private float movementSpeed = 3;
    private float JumpForce = 5;
    float movement;

    private Vector3 direction;

    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
    }

    private void Update()
    {
        // player movement
        movement = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * movementSpeed;

        // player rotation change
        if (movement < 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0f, 180, 0));
        }
        else if (movement > 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0f, 0, 0));
        }

        // player Jump
        if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
        {
            _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

   
    void Shoot()
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // collider detects "enemy"
        if (other.gameObject.CompareTag("enemy")) {
            //GameOver
            FindObjectOfType<GameManager2D>().GameOver();
        }

        // collider detects "Clock"
        if (other.gameObject.CompareTag("Clock"))
        {
            // Time Add 5Clock
            RemainTime.GetComponent<Countdown>().TimeAdd();
            Destroy(other.gameObject);
        }
    }

}
