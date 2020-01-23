using UnityEngine;
using UnityEngine.SceneManagement;

public class UIGameMenu : MonoBehaviour {
    
    public void Buttons(string option) {
        
        if(option == "QUIT")
            Application.Quit();

        else
            SceneManager.LoadScene(option);
    }
}