using UnityEngine;
using UnityEngine.UI;

public class LanguageButton : MonoBehaviour
{
    public Language Language;
    private Text localizedText;

    public void Start()
    {
        localizedText = gameObject.GetComponentInChildren<Text>();
        localizedText.text = Language.ToString();
    }

    public void PressLanguageButton()
    {
        Language += 1;
        if (Language > Language.Español) Language = Language.English;

        Localizer.SetLanguage(Language);
        localizedText.text = Language.ToString();
    }
}
