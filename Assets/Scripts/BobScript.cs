using UnityEngine;

public class BobScript : MonoBehaviour
{
    private GameObject player;
    //[SerializeField] private float bobPower;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        //if (other.gameObject.layer.Equals("Ground"))
        {
            float distanceBetweenX = transform.position.x - player.transform.position.x;
            float distanceBetweenY = player.transform.position.y - transform.position.y;
            player.GetComponent<PlayerMovement>().DashMovement(distanceBetweenX, distanceBetweenY);
            Destroy(gameObject);
        }
    }
}
