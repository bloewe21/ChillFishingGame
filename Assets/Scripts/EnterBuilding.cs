using System.Collections;
using UnityEngine;

public class EnterBuilding : MonoBehaviour
{
    [Header("Fade")]
    [SerializeField] private float fadeSpeed;

    [Header("References")]
    [SerializeField] private GameObject blackBG;
    [SerializeField] private GameObject buildingExterior;
    [SerializeField] private GameObject buildingWalls;
    [SerializeField] private GameObject buildingCam;
    [SerializeField] private GameObject myIcon;

    [Header("Extra")]
    private bool isInside = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            myIcon.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            myIcon.SetActive(false);
        }
    }

    public void UseDoor()
    {
        if (isInside)
        {
            isInside = false;

            StopAllCoroutines();
            buildingWalls.SetActive(false);
            buildingCam.SetActive(false);
            StartCoroutine(FadeIn(gameObject, fadeSpeed * 2.0f, 1f));
            StartCoroutine(FadeIn(buildingExterior, fadeSpeed, 1f));
            StartCoroutine(FadeOut(blackBG, fadeSpeed, 0f));
        }
        else
        {
            isInside = true;
            
            StopAllCoroutines();
            buildingWalls.SetActive(true);
            buildingCam.SetActive(true);
            StartCoroutine(FadeOut(gameObject, fadeSpeed * 2.0f, 0.5f));
            StartCoroutine(FadeOut(buildingExterior, fadeSpeed, 0f));
            StartCoroutine(FadeIn(blackBG, fadeSpeed, 1f));
        }
    }

    private IEnumerator FadeOut(GameObject currObject, float fadeSpeed, float newAlpha)
    {
        SpriteRenderer sr = currObject.transform.GetComponent<SpriteRenderer>();
        Color matColor = sr.color;
        float alphaValue = sr.color.a;

        while (alphaValue > newAlpha)
        {
            alphaValue -= Time.deltaTime / fadeSpeed;
            sr.color = new Color(matColor.r, matColor.g, matColor.b, alphaValue);
            yield return null;
        }
    }

    private IEnumerator FadeIn(GameObject currObject, float fadeSpeed, float newAlpha)
    {
        SpriteRenderer sr = currObject.transform.GetComponent<SpriteRenderer>();
        Color matColor = sr.color;
        float alphaValue = sr.color.a;

        while (alphaValue < newAlpha)
        {
            alphaValue += Time.deltaTime / fadeSpeed;
            sr.color = new Color(matColor.r, matColor.g, matColor.b, alphaValue);
            yield return null;
        }
    }
}
