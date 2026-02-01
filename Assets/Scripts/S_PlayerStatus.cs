using UnityEngine;
/*
 * Name: Erin Scribner
 * Date: 1/31/2026
 * Summary: Stores the player's reputation stat & suspicion stat
 */
public class S_PlayerStatus : MonoBehaviour
{
    private float currentReputation; //the player's current reputation value
    private float currentSuspicion; //the player's current suspicion value

   /*
    * Initialize private variables
    */
    void Start()
    {
        currentReputation = 1;
        currentSuspicion = 1;
    }

    /*
     * Update currentRep with the given value
     */
    public void SetReputation(float value)
    {
        currentReputation = value;
    }

    /*
     * Return the current reputation value
     */
    public float GetReputation()
    {
        return currentReputation;
    }

    /*
    * Update currentSus with the given value
    */
    public void SetSuspicion(float value)
    {
        currentSuspicion = value;
    }

    /*
     * Return the current suspicion value
     */
    public float GetSuspicion()
    {
        return currentSuspicion;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
