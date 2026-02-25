using UnityEngine;

public class DropDownButton : MonoBehaviour
{
    public Language Language;

    public void DownButton(int index)
    {
        switch (index)
        {
            case 0:
                Language = Language.English;
                break;
            case 1:
                Language = Language.Catala;
                break;
            case 2:
                Language = Language.Español;
                break;     
        }

        Localizer.SetLanguage(Language);
    }
}
