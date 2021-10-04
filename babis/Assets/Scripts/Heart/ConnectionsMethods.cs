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
}
