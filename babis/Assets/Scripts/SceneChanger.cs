using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private Transform helpPanel;
    [SerializeField] private Transform autorsPanel;
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
}
