using UnityEngine;
using UnityEngine.InputSystem.XR;

public class QuickTimeGoalNeedle : MonoBehaviour
{

    bool inStuff;

    [SerializeField]
    private QuickTimeNeedleController controller;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && inStuff)
        {
            controller.SwapDirection();
            controller.IncreaseSpeed();
            SetRandRot();
        }

    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Target"))
        {
            inStuff = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Target"))
        {
            inStuff = false;
        }
    }

    private void SetRandRot()
    {
        transform.RotateAround(new Vector3(0, 0, 0), Vector3.forward, Random.Range(-90f, 90f) );
    }
}
