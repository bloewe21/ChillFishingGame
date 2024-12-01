using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class QuickTimeNeedleController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.rotation *= Quaternion.Euler(0, 1, 0);
        transform.RotateAround( new Vector3(0,0,0), Vector3.forward, 120 * Time.deltaTime);
    }
}
