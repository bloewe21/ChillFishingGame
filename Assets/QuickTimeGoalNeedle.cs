using UnityEngine;

public class QuickTimeGoalNeedle : MonoBehaviour
{
    [SerializeField]
    private GameObject Needle;

    Collider2D col;
    Collider2D NeedlCol;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //InvokeRepeating("SetRandRot", 1f, 1f);
        col = GetComponent<Collider2D>(); 
        NeedlCol = Needle.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (col.IsTouching(NeedlCol))
            {
                print("2");
                SetRandRot();
            }


        }

    }

    private void CheckCol()
    {
        
    }

    private void FixedUpdate()
    {
        
    }

    private void SetRandRot()
    {
        transform.RotateAround(new Vector3(0, 0, 0), Vector3.forward, Random.Range(-90f, 90f) );

    }
}
