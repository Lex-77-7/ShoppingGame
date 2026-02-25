using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void Update()
    {
        if ((Keyboard.current != null) && Keyboard.current.enterKey.wasPressedThisFrame)
        {
            StartGame();
        }
    }
}
