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
        special
    }
    public dotType type;
    public string special_connect;
    public string sp_func;
}
