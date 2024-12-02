using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.UI;

public class RodMovement : MonoBehaviour
{
    [Header("Bob")]
    [SerializeField] private GameObject bob;
    [SerializeField] private float bobForceX;
    [SerializeField] private float bobForceY;
    private GameObject currentBob;

    [Header("Slider")]
    [SerializeField] private GameObject slider;
    private bool sliderActive = false;
    private bool sliderIncreasing = true;
    private float sliderValue;

    [Header("References")]
    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            sliderActive = true;
            if (slider.GetComponent<Slider>().value >= slider.GetComponent<Slider>().maxValue)
            {
                sliderIncreasing = false;
            }
            else if (slider.GetComponent<Slider>().value <= slider.GetComponent<Slider>().minValue)
            {
                sliderIncreasing = true;
            }

            if (sliderIncreasing)
            {
                slider.GetComponent<Slider>().value += Time.deltaTime;
            }
            else
            {
                slider.GetComponent<Slider>().value -= Time.deltaTime;
            }
        }

        sliderValue = slider.GetComponent<Slider>().value;

        if (Input.GetButtonUp("Fire1") && sliderActive)
        {
            sliderActive = false;
            currentBob = Instantiate(bob, transform.position, Quaternion.identity);

            //y force
            currentBob.GetComponent<Rigidbody2D>().linearVelocityY = bobForceY;

            //x force
            float playerSpeed = rb.linearVelocityX / 1.5f;
            if (GetComponent<PlayerMovement>().facingRight)
            {
                if (playerSpeed >= 0f)
                {
                    currentBob.GetComponent<Rigidbody2D>().linearVelocityX = (playerSpeed + bobForceX) * sliderValue;
                }
                else
                {
                    currentBob.GetComponent<Rigidbody2D>().linearVelocityX = bobForceX * sliderValue;
                }
            }
            else
            {
                if (playerSpeed <= 0f)
                {
                    currentBob.GetComponent<Rigidbody2D>().linearVelocityX = (playerSpeed + -bobForceX) * sliderValue;
                }
                else
                {
                    currentBob.GetComponent<Rigidbody2D>().linearVelocityX = -bobForceX * sliderValue;
                }
            }

            slider.GetComponent<Slider>().value = 0;
        }
    }
}
