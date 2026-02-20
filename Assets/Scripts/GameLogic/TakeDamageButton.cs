using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageButton : MonoBehaviour
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

    public void OnClickTakeDamage()
    {
        currentIndex++;

        if (currentIndex >= HealthSprites.Count)
        {
            currentIndex = HealthSprites.Count - 1;
        }

        gameObject.GetComponent<SpriteRenderer>().sprite = HealthSprites[currentIndex];
    }
}
