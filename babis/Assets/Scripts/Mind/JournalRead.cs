using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JournalRead : MonoBehaviour
{
    [SerializeField] private JournalWritings journal;
    private Text _uiText;
    void Start()
    {
        _uiText = GetComponent<Text>();
        _uiText.text = "";
        ReadJournal();
    }

    private void ReadJournal()
    {
        for (int i = 0; i < journal.combinations.Count; i++)
        {
            _uiText.text += journal.combinations[i] + "\n";
        }
    }
}
