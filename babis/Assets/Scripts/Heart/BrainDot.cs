using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BrainDot
{
    [Serializable]
    public class SP 
    {
        public string special_connect;
        public string sp_func;
    }

    public string name;
    public string description;
    public enum dotType 
    {
        obj,
        action,
        drink,
        special,
        eyes
    }
    public dotType type;
    public int scoreInc = 0;
    public int multi = 0;
    //public string special_connect;
    //public string sp_func;
    public List<SP> special;

    public static void Copy(BrainDot from, ref BrainDot to) 
    {
        to.name = from.name;
        to.description = from.description;
        to.type = from.type;
        to.scoreInc = from.scoreInc;
        to.multi = from.multi;
        foreach (var sp in from.special)
            to.special.Add(sp);


        //to.special_connect = from.special_connect;
        //to.sp_func = from.sp_func;
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
