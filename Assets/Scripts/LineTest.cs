using UnityEngine;

public class LineTest : MonoBehaviour
{
    [SerializeField] private Transform[] points;
    [SerializeField] private LineController line;

    // Start is called before the first frame update
    void Start()
    {
        points[0] = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Bob").Length == 0) {
            points[1] = GameObject.FindWithTag("Player").transform;
        }
        else {
            points[1] = GameObject.FindWithTag("Bob").transform;
        }
        line.SetUpLine(points);
    }
}
