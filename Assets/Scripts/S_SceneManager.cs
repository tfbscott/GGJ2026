using UnityEngine;
using UnityEngine.SceneManagement;
/* Name: Erin Scribner
 * Date: 1/30/2026
 * Summary: Allows user to choose which scene to go to when the public function is called. 
 * 
 * 
 */
public class S_SceneManager : MonoBehaviour
{
    public enum scenes {MainMenu, Credits, LoseScreen, WinScreen, Game};
    public scenes goTo;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    /*
     * Loads the scene that corresponds with what goTo equals. 
     */
    public void NextScene()
    {
        switch (goTo)
        {
            //if goTo = mainMenu, then load in the main menu scene
            case scenes.MainMenu:
                SceneManager.LoadScene("MainMenu");
                break;
            //if goTo = credits, then load in the credits scene
            case scenes.Credits:
                SceneManager.LoadScene("Credits");
                break;
            //if goTo = game, then load in the game scene
            case scenes.Game:
                SceneManager.LoadScene("Game");
                break;
            //if goTo = lose, then load in the lose scene
            case scenes.LoseScreen:
                SceneManager.LoadScene("LoseScreen");
                break;
            //if goTo = win, then load in the win scene
            case scenes.WinScreen:
                SceneManager.LoadScene("WinScreen");
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
