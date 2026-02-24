using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour, IConsume
{
    [SerializeField] private int MaxLife = 100;
    private int life; //Goes from 100 -> 75 -> 50 -> 25 -> 0
    public static event Action<int> OnLifeChanged;

    public void Awake()
    {
        life = MaxLife;
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
        if (item is ItemPotion potion)
        {
            if (life >= MaxLife) return false;

            life += potion.Health;
            life = Mathf.Clamp(life, 0, MaxLife);
            OnLifeChanged?.Invoke(life);

            return true;
        }
        else if (item is ItemFood food)
        { //Una vez tengamos stamina cambiar a stamina.
            if (life >= MaxLife) return false;
            life += food.Energy;
            life = Mathf.Clamp(life, 0, MaxLife);
            OnLifeChanged?.Invoke(life);
            return true;

        }

        return false;
    }
}
