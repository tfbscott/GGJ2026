using UnityEngine;
/*
 * Name: Erin Scribner
 * Date: 1/31/2026
 * Summary: When player is within range of the NPC, button to intiate
 *          dialogue appears
 */
public class S_Interact : MonoBehaviour
{
    [Tooltip("The interactable object to appear")]
    public GameObject button;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    /*
     * When player is within interactable range, 
     * show the interactable object
     */
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            button.SetActive(true);
        }
    }

    /*
     * When player leaves interactable range, 
     * disable the interactable object
     */
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            button.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
