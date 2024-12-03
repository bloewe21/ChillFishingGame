using UnityEngine;

public class BobScript : MonoBehaviour
{
    [Header("Bob")]
    [SerializeField] private float bobbingForce;
    private bool inWater;

    [Header("References")]
    private GameObject player;
    private Rigidbody2D rb;
    //[SerializeField] private float bobPower;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inWater)
        {
            rb.linearDamping = 5;
            rb.AddForce(new Vector2(0f, bobbingForce));
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            float distanceBetweenX = transform.position.x - player.transform.position.x;
            float distanceBetweenY = player.transform.position.y - transform.position.y;
            player.GetComponent<PlayerMovement>().DashMovement(distanceBetweenX, distanceBetweenY);
            Destroy(gameObject);
        }

        if (other.CompareTag("Water"))
        {
            inWater = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Water"))
        {
            inWater = false;
        }
    }
}
