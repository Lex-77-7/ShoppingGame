using System.Collections.Generic;
using UnityEngine;

public class LifebarUI : MonoBehaviour
{
    public List<Sprite> HealthSprites;

    public void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = HealthSprites[0];
    }

    private void OnEnable()
    {
        PlayerLife.OnLifeChanged += UpdateLifebar;
    }

    private void OnDisable()
    {
        PlayerLife.OnLifeChanged -= UpdateLifebar;
    }

    public void UpdateLifebar(int life)
    {
        int spriteIndex = Mathf.RoundToInt(
            ((100 - life) / 100.0f) * (HealthSprites.Count - 1)
        );

        gameObject.GetComponent<SpriteRenderer>().sprite = HealthSprites[spriteIndex];
    }
}
