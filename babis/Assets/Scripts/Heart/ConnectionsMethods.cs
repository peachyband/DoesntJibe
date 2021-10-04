using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConnectionsMethods : MonoBehaviour
{

    [SerializeField] private Text thoughths;
    [SerializeField] private ProgressCalculator pcalc;
    public int multiplier = 1;
    public void ShowDescription(string val) 
    {
        thoughths.text = val;
    }

    public void ScoreInc(int val)
    {
        //char p;
        //if (val < 0) { p = '-'; val = -val; }
        //else p = '+';
        //Debug.Log(p + val);
        //thoughths.text = p + val.ToString();
        pcalc.progressScale += val;
    }

    public void SetMulti(int val) 
    {
        multiplier = val;
        if (val != 1) Debug.Log("Mult = x" + val);
    }
}
