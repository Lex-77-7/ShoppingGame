using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour, IConsume
{
    [SerializeField] private int maxLife = 100;
    private int life; // Goes from 100 -> 75 -> 50 -> 25 -> 0

    public static event Action<int> OnLifeChanged;

    public void Awake()
    {
        life = maxLife;
    }

    private void OnEnable()
    {
        LifeEventEmitter.OnTakeDamage += LoseLife;
    }

    private void OnDisable()
    {
        LifeEventEmitter.OnTakeDamage -= LoseLife;
    }

    private void LoseLife()
    {
        life -= 25;
        OnLifeChanged?.Invoke(life);

        if (life <= 0) SceneManager.LoadScene("Ending");
    }

    public bool Consume(Consummable item)
    {
        if (item is Consummable consummable)
        {
            if (life >= maxLife) return false;

            life += consummable.LifeRestore;
            life = Mathf.Clamp(life, 0, maxLife);

            OnLifeChanged?.Invoke(life);
            return true;
        }

        return false;
    }
}
