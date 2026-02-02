using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
/*
 * Name: Erin Scribner
 * Date: 1/31/2026
 * Summary: Stores the player's reputation stat & suspicion stat
 */
public class S_PlayerStatus : MonoBehaviour
{
    [SerializeField]
    private PlayerDataBehavior _playerData;

    [SerializeField] 
    private GameObject _rejectionBubble;

    private float currentReputation => _playerData.Status; //the player's current reputation value
    private float currentSuspicion => _playerData.Suspicion; //the player's current suspicion value

    /*
     * Return the current reputation value
     */
    public float GetReputation()
    {
        return currentReputation;
    }

    public void DisplayRejection()
    {
        _rejectionBubble.SetActive(true);
        StartCoroutine(RejectionCoroutine());
    }

        
    private IEnumerator RejectionCoroutine()
    {
        yield return new WaitForSeconds(5.0f);
        _rejectionBubble.SetActive(false);
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
