using UnityEngine;
public class QuitButton : MonoBehaviour {
    public void onClick() {
        Debug.Log("Closing application...");
        Application.Quit();
    }
}