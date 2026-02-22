using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TakeDamageButton : MonoBehaviour
{
    public List<Sprite> HealthSprites;
    private int currentIndex = 0;

    public static event Action OnTakeDamage;

    public void Awake()
    {
        currentIndex = 0;
    }

    public void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = HealthSprites[0];
    }

    public void OnClickTakeDamage()
    {
        currentIndex++;
        OnTakeDamage?.Invoke();

        if (currentIndex >= HealthSprites.Count - 1)
        {
            SceneManager.LoadScene("Ending");
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = HealthSprites[currentIndex];
        }
    }
}
