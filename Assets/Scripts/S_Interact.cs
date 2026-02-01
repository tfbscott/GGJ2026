using System;
using Configs;
using UnityEngine;
using UnityEngine.InputSystem;

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
    public NPCBehavior npcBehavior;
    private GameObject player; //store player gameobject data
    private PlayerInputActions inputActions;

    private bool canInteract = false;

    private void Awake()
    {
        inputActions = new PlayerInputActions();
        
        inputActions.Player.Interact.started += OnInteract;
    }

    /*
     * Initialize private variables
     */
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnEnable()
    {
        inputActions.Player.Enable();
    }

    private void OnDisable()
    {
        inputActions.Player.Disable();
    }

    private void OnInteract(InputAction.CallbackContext obj)
    {
        if (!canInteract || !CheckReputation())
        {
            return;
        }
        
        npcBehavior.DisplayDialogueInterface();
        if(player.transform.position.x <= npcBehavior.transform.position.x)
        {
            //NPC flips left
            npcBehavior.transform.rotation = Quaternion.Euler(0, -180, 0);
        }
        //if player is to the right of the NPC
        if(player.transform.position.x > npcBehavior.transform.position.x)
        {
            //NPC flips right
            npcBehavior.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
    

    /*
     * Checks to see if the player can talk to the NPC
     */
    bool CheckReputation()
    { 
        //player's reputation
        int pR = (int)player.GetComponent<S_PlayerStatus>().GetReputation();
        //NPC's reputation
        int nR = npcBehavior.GetRep();
        //true if player's rep is >= NPC's rep
        return (pR >= nR) && !npcBehavior.HasBeenTalkedTo;
    }

    /*
     * When player is within interactable range, 
     * show the interactable object
     */
    void OnTriggerEnter2D(Collider2D collision)
    {
        //if player triggers gameobject & has enough reputation
        if(collision.gameObject.tag == "Player")
        {
            button.SetActive(true);
            canInteract = true;
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
            canInteract = false;
        }
    }
}
