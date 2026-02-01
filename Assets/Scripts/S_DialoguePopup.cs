using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;
/*
 * Name: Erin Scribner
 * Date: 1/31/2026
 * Summary: When object is clicked, display the NPC's dialogue
 */
public class S_DialoguePopup : MonoBehaviour
{
    [Tooltip("The NPC prefab")]
    public GameObject parent;
    private GameObject player; //the player character
   
    /*
     * Initialize private variables
     */
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    /*
     * When gameobject is clicked, display the NPC's dialogue
     */
    private void OnMouseDown()
    {
        parent.GetComponent<NPCBehavior>().DisplayDialogueInterface();
        //if player is to the left of the NPC
        if(player.transform.position.x <= parent.transform.position.x)
        {
            //NPC flips left
            parent.transform.rotation = Quaternion.Euler(0, -180, 0);
        }
        //if player is to the right of the NPC
        if(player.transform.position.x > parent.transform.position.x)
        {
            //NPC flips right
            parent.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
