using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private Transform helpPanel;
    [SerializeField] private Transform autorsPanel;
    [SerializeField] private Transform brainPanel;
    public Text bb;
    public IEnumerator ChangeScene(int sceneOrder, float timeToLoad)
    {
        yield return new WaitForSeconds(timeToLoad);
        SceneManager.LoadScene(sceneOrder);
    }
    public void OpenHelpMenuItem()
    {
        helpPanel.gameObject.SetActive(true);
    }
    public void OpenAutorsMenuItem()
    {
        autorsPanel.gameObject.SetActive(true);
    }

    public void OpenBrainPanel()
    {
        if(brainPanel) brainPanel.gameObject.SetActive(true);
    }

    public void CloseBrainPanel()
    {
        if(brainPanel) brainPanel.gameObject.SetActive(false);
    }
    
    public void ChangeSceneWithButton(int sceneOrder)
    {
        StartCoroutine(ChangeScene(sceneOrder, 3));
    }
}
