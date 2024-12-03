using UnityEngine;

public class SwitchCam : MonoBehaviour
{

    public GameObject mainCam;
    public GameObject virtualCam;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            print("zoo wee");
            mainCam.SetActive(false);
            virtualCam.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            mainCam.SetActive(true);
            virtualCam.SetActive(false);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        //Gizmos.Draw(transform.position, GetComponent<PolygonCollider2D>().bounds)
    }
}
