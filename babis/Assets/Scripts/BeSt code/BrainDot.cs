using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BrainDot
{
    public string name;
    public string description;
    public enum dotType 
    {
        obj,
        drink,
        action,
        special,
        eyes
    }
    public dotType type;
    public string special_connect;
    public string sp_func;

    public static void Copy(BrainDot from, ref BrainDot to) 
    {
        to.name = from.name;
        to.description = from.description;
        to.type = from.type;
        to.special_connect = from.special_connect;
        to.sp_func = from.sp_func;
    }

    public static int GetDominante(dotType a, dotType b)
    {
        if ((int)a > (int)b)
            return 0;
        else if ((int)a < (int)b)
            return 1;
        else return -1;
    }
}
