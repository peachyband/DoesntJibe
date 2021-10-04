using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private Transform helpPanel;
    [SerializeField] private Transform autorsPanel;
    public IEnumerator ChangeScene(int sceneOrder, float timeToLoad)
    {
        yield return new WaitForSeconds(timeToLoad);
        SceneManager.LoadScene(sceneOrder);
    }

    public void OpenHelpMenuItem()
    {
        autorsPanel.gameObject.SetActive(true);
    }
    public void OpenAutorsMenuItem()
    {
        helpPanel.gameObject.SetActive(true);
    }
}
