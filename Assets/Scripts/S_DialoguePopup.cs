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
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
