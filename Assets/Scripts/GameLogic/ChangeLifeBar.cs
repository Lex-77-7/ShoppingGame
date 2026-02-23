using System.Collections.Generic;
using UnityEngine;

public class ChangeLifeBar : MonoBehaviour
{
    public List<Sprite> HealthSprites;
    private int currentIndex = 0;

    public void Awake()
    {
        currentIndex = 0;
    }

    public void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = HealthSprites[0];
    }

    private void OnEnable()
    {
        TakeDamageButton.OnTakeDamage += LoseLife;
    }
    
    private void OnDisable()
    {
        TakeDamageButton.OnTakeDamage -= LoseLife;
    }

    public void LoseLife()
    {
        currentIndex++;

        if (currentIndex < HealthSprites.Count)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = HealthSprites[currentIndex];
        }
    }
}
