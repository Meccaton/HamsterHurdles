using TMPro;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    public TMP_Text jumpKey;
    public GameObject panel;
    public string jumpText;

    private RectTransform rt;


    private void Start()
    {
        rt = panel.GetComponent<RectTransform>();
    }

    public void UpdateJumpKey(KeyCode kc)
    {
        string keyName = ShortenString(kc);

        jumpKey.text = keyName;
        Vector2 newSize = rt.sizeDelta;

        switch (keyName.Length){
            case 1:
                newSize.x = 60;
                break;
            case 2:
                newSize.x = 60;
                break;
            case 3:
                newSize.x = 80;
                break;
            default:
                newSize.x = 150;
                break;
        }
        rt.sizeDelta = newSize;
    }

    public string ShortenString(KeyCode kc)
    {
        switch (kc)
        {
            case KeyCode.UpArrow:
                return "Up";
            case KeyCode.RightArrow:
                return "Right";
            case KeyCode.DownArrow:
                return "Down";
            case KeyCode.LeftArrow:
                return "Left";
            case KeyCode.BackQuote:
                return "`";
            case KeyCode.CapsLock:
                return "Cap";
            case KeyCode.Minus:
                return "-";
            case KeyCode.Equals:
                return "=";
            case KeyCode.Backspace:
                return "Back";
            case KeyCode.LeftBracket:
                return "[";
            case KeyCode.RightBracket:
                return "]";
            case KeyCode.Backslash:
                return "\\";
            case KeyCode.Semicolon:
                return ";";
            case KeyCode.Quote:
                return "'";
            case KeyCode.Comma:
                return ",";
            case KeyCode.Period:
                return ".";
            case KeyCode.Slash:
                return "/";
            default:
                string keyName = kc.ToString();

                if (keyName.StartsWith("Alpha"))
                {
                    return keyName.Replace("Alpha", "");
                }

                if (keyName.StartsWith("Left"))
                {
                    return keyName.Replace("Left", "L-");
                }

                if (keyName.StartsWith("Right"))
                {
                    return keyName.Replace("Right", "R-");
                }
                return keyName;
        }
    }
}
