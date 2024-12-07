using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [Header("Building")]
    private GameObject currentDoor;
    private bool canUseDoor = false;

    [Header("NPC")]
    private GameObject currentNPC;
    private bool canTalk = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //within box trigger of interactable
        if (Input.GetButtonDown("Submit"))
        {
            //trigger on door
            if (canUseDoor)
            {
                currentDoor.GetComponent<EnterBuilding>().UseDoor();
            }
            //trigger on NPC
            else if (canTalk)
            {
                currentNPC.GetComponent<NPCTalk>().StartTalk();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Door"))
        {
            canUseDoor = true;
            currentDoor = other.gameObject;
        }

        if (other.CompareTag("NPC"))
        {
            canTalk = true;
            currentNPC = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Door"))
        {
            canUseDoor = false;
        }

        if (other.CompareTag("NPC"))
        {
            canTalk = false;
        }
    }
}
