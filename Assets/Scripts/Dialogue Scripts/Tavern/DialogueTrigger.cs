using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

    //main dialogue gameObject
    GameObject barkeepBranDialogue;

    private bool playerInRange;

    //is dialogue currently showing
    public static bool isDialogueShowing;
    private void Awake()
    {
        barkeepBranDialogue = GameObject.Find("BarkeepBranDialogue");
        playerInRange = false;
        visualCue.SetActive(false);
        barkeepBranDialogue.SetActive(false);
    }

    private void Update()
    {
        // If player is in range
        if (playerInRange && isDialogueShowing == false)
        {

            visualCue.SetActive(true);
            
        }
        else
        {
            visualCue.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }

    // Click mouse left key to show dialogue
    public void DisplayDialogue()
    {
        if ( GameManager.isDialogueShowing == false)
        {
            // show dialogue here
            barkeepBranDialogue.SetActive(true);

            // Set dialogue status
            GameManager.isDialogueShowing = true;
        }
    }
}