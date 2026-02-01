using Configs;
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
    private GameObject player; //store player gameobject data

    /*
     * Initialize private variables
     */
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    /*
     * Checks to see if the player can talk to the NPC
     */
    bool CheckReputation()
    { 
        //player's reputation
        int pR = (int)player.GetComponent<S_PlayerStatus>().GetReputation();
        //NPC's reputation
        int nR = transform.parent.gameObject.GetComponent<NPCBehavior>().GetRep();
        //true if player's rep is >= NPC's rep
        return (pR >= nR);
    }

    /*
     * When player is within interactable range, 
     * show the interactable object
     */
    void OnTriggerEnter2D(Collider2D collision)
    {
        //if player triggers gameobject & has enough reputation
        if(collision.gameObject.tag == "Player" && CheckReputation() == true)
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
