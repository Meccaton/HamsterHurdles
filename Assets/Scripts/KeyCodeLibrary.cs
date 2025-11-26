using System.Collections.Generic;
using UnityEngine;

public class KeyCodeLibrary : MonoBehaviour
{
    public List<KeyCode> level1Library;
    public List<KeyCode> level2Library;
    public List<KeyCode> level3Library;

    void Start()
    {
        level1Library = new List<KeyCode>
        {
            KeyCode.A, KeyCode.B, KeyCode.C, KeyCode.D, KeyCode.E, KeyCode.F, KeyCode.G, KeyCode.H,
            KeyCode.I, KeyCode.J, KeyCode.K, KeyCode.L, KeyCode.M, KeyCode.N, KeyCode.O, KeyCode.P,
            KeyCode.Q, KeyCode.R, KeyCode.S, KeyCode.T, KeyCode.U, KeyCode.V, KeyCode.W, KeyCode.X,
            KeyCode.Y, KeyCode.Z
        };

        level2Library = new List<KeyCode>
        {
            KeyCode.BackQuote, KeyCode.Tab, KeyCode.CapsLock, KeyCode.LeftShift, KeyCode.LeftShift,
            KeyCode.LeftAlt, KeyCode.Alpha0, KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4,
            KeyCode.Alpha5, KeyCode.Alpha6, KeyCode.Alpha7, KeyCode.Alpha8, KeyCode.Alpha9, KeyCode.Alpha0,
            KeyCode.Minus, KeyCode.Equals, KeyCode.Backspace, KeyCode.LeftBracket, KeyCode.RightBracket,
            KeyCode.Backslash, KeyCode.Semicolon, KeyCode.Quote, KeyCode.Comma, KeyCode.Period,
            KeyCode.Slash, KeyCode.RightShift, KeyCode.RightAlt, KeyCode.RightControl,
            KeyCode.UpArrow, KeyCode.RightArrow, KeyCode.DownArrow, KeyCode.LeftArrow
        };

        level3Library = new List<KeyCode>
        {
            KeyCode.Delete, KeyCode.Insert, KeyCode.End, KeyCode.Home, KeyCode.Escape//, KeyCode.F1, 
            //KeyCode.F2, KeyCode.F3, KeyCode.F4, KeyCode.F5, KeyCode.F6, KeyCode.F7, KeyCode.F8,
            //KeyCode.F9, KeyCode.F10, KeyCode.F11, KeyCode.F12
        };
    }

    public KeyCode getEz()
    {
        int idx = Random.Range(0, level1Library.Count);
        return level1Library[idx];
    }

    public KeyCode getMid()
    {
        int chance = Random.Range(0, 100);
        int idx;
        if(chance < 50)
        {
            idx = Random.Range(0, level1Library.Count);
            return level1Library[idx];
        }
        else
        {
            idx = Random.Range(0, level2Library.Count);
            return level2Library[idx];
        }
    }

    public KeyCode getHard()
    {
        int chance = Random.Range(0, 100);
        int idx;
        if (chance < 50)
        {
            idx = Random.Range(0, level2Library.Count);
            return level2Library[idx];
        }
        else
        {
            idx = Random.Range(0, level3Library.Count);
            return level3Library[idx];
        }
    }
}
