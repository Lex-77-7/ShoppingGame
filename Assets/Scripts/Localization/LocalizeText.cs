using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LocalizeText : MonoBehaviour
{
    public string TextKey;
    private Text textValue;

    void Start()
    {
        textValue = GetComponent<Text>();
        textValue.text = Localizer.GetText(TextKey);
    }

    private void OnEnable()
    {
        Localizer.OnLanguageChange += ChangeLanguage;
    }

    private void OnDisable()
    {
        Localizer.OnLanguageChange -= ChangeLanguage;
    }

    private void ChangeLanguage()
    {
        textValue.text = Localizer.GetText(TextKey);
    }
}
