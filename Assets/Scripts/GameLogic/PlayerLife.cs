using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private int life = 100; //Goes from 100 -> 75 -> 50 -> 25 -> 0

    private void OnEnable()
    {
        TakeDamageButton.OnTakeDamage += LoseLife;
    }

    private void OnDisable()
    {
        TakeDamageButton.OnTakeDamage -= LoseLife;
    }

    private void LoseLife()
    {
        life -= 25;

        if (life <= 0) SceneManager.LoadScene("Ending");
    }

    private void HealLife()
    {

    }
}
