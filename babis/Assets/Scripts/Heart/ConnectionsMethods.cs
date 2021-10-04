using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConnectionsMethods : MonoBehaviour
{

    [SerializeField] private Text thoughths;
    public void ShowDescription(string val) 
    {
        thoughths.text = val;
    }

    public void ScoreInc(int val)
    {
        char p;
        if (val < 0) { p = '-'; val = -val; }
        else p = '+';
        Debug.Log(p + val);
        thoughths.text = p + val.ToString();
    }
}
