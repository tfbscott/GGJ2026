using UnityEngine;
using UnityEngine.UI;
/*
 * Name: Erin Scribner
 * Date: 1/31/2026
 * Summary: Showcases logic on how to decrement/increment the 
 *          reputation and suspicion bars
 * 
 */
public class S_Tmp : MonoBehaviour
{
    [Tooltip("The colored part of the bar image")]
    public Image coloredImage;
    [Tooltip("How quickly the bar should move UP")]
    public float incrementValue;
    [Tooltip("How quickly the bar should move DOWN")]
    public float decrementValue;
    private float currentValue; //the bar's current value
    private GameObject player; //stores the player gameobject
    /*
     * Initialize starting position of the bar
     */
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        currentValue = 1;
        coloredImage.fillAmount = currentValue / 10;
    }

    /*
     * increment/decrement the bar's value based on the 
     * addOrsubtract variable
     */
    void ManipulateBar(float addOrsubtract)
    {
        //update currentvalue, making sure it doesn't go out of bounds
        currentValue = Mathf.Clamp(currentValue += (addOrsubtract * incrementValue), 0, 10);
        //update player's reputation
        player.GetComponent<S_PlayerStatus>().SetReputation(currentValue);
        //update the bar's image to reflect its current value
        coloredImage.fillAmount = currentValue / 10;
    }





   
    /*
     * Showcases how the bar values should increase/decrease
     */
    void Update()
    {
        //when the condition to increase value is met
        if(Input.GetKeyDown(KeyCode.W))
        {
            //call ManipulateBar using 1 to incremnet
            ManipulateBar(1);
        }
        //When the condition to decrease value is met
        else if(Input.GetKeyDown(KeyCode.S))
        {
            //call ManipulateBar using -1 to decrement
            ManipulateBar(-1);
        }
    }
}
