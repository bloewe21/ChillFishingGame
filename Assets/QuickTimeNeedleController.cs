using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class QuickTimeNeedleController : MonoBehaviour
{

    Vector3 ccw = new Vector3(0, 0, 1);

    Vector3 cc = new Vector3(0, 0, -1);
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private Vector3 RotDirection;

    private float speed = 120f;
    void Start()
    {
        RotDirection = cc;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.rotation *= Quaternion.Euler(0, 1, 0);
        transform.RotateAround( new Vector3(0,0,0), RotDirection , speed * Time.deltaTime);
    }



    public void SwapDirection()
    {
        RotDirection *= -1;
    }

    public void IncreaseSpeed()
    {
        speed += 20f;
    }
}
