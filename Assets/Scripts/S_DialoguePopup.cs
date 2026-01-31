using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
/*
 * Name: Erin Scribner
 * Date: 1/31/2026
 * Summary: When object is clicked, display the NPC's dialogue
 */
public class S_DialoguePopup : MonoBehaviour
{
    [Tooltip("The NPC prefab")]
    public GameObject parent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    /*
     * When gameobject is clicked, display the NPC's dialogue
     */
    private void OnMouseDown()
    {
        parent.GetComponent<NPCBehavior>().DisplayDialogueInterface();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
