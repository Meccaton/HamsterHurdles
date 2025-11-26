using TMPro;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    public TMP_Text jumpKey;
    public TMP_Text jumpKey2;
    public GameObject panel;
    public GameObject panel2;
    public string jumpText;

    private RectTransform rt;
    private RectTransform rt2;

    private void Start()
    {
        rt = panel.GetComponent<RectTransform>();
        rt2 = panel2.GetComponent<RectTransform>();
    }

    public void EnableSecondKey()
    {
        panel2.SetActive(true);
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

    public void UpdateTwoJumpKeys(KeyCode kc1, KeyCode kc2)
    {
        string keyName1 = ShortenString(kc1);
        string keyName2 = ShortenString(kc2);

        jumpKey.text = keyName1;
        Vector2 newSize = rt.sizeDelta;
        jumpKey2.text = keyName2;
        Vector2 newSize2 = rt2.sizeDelta;

        switch (keyName1.Length)
        {
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

        switch (keyName2.Length)
        {
            case 1:
                newSize2.x = 60;
                break;
            case 2:
                newSize2.x = 60;
                break;
            case 3:
                newSize2.x = 80;
                break;
            default:
                newSize2.x = 150;
                break;
        }
        rt2.sizeDelta = newSize2;
    }

    public string ShortenString(KeyCode kc)
    {
        switch (kc)
        {
            case KeyCode.LeftControl:
                return "L-Ctrl";
            case KeyCode.RightControl:
                return "R-Ctrl";
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
