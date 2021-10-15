using System.Security.Cryptography;
using UnityEngine;

public class MindAnalizer : MonoBehaviour
{
    [SerializeField] private LineDrawer lineDrawer;
    [SerializeField] private SceneChanger sceneChanger;
    private void Update()
    {
        foreach (Transform child in transform)
        {
            LineDrawer.NeighboorNet newNet = child.GetComponent<LineDrawer.NeighboorNet>();
            string actionKey = new string('-', 1);
            newNet.neighboors.ForEach(neighboor => { actionKey += neighboor.name.ToString(); });
            if (actionKey.Equals("-TouchPlay") || actionKey.Equals("-PlayTouch"))
            {
                Debug.Log("start game");
                StartCoroutine(sceneChanger.ChangeScene(1, 1));
                sceneChanger.CloseBrainPanel();
                lineDrawer.DeleteConnection(newNet, newNet.netIndex);
            }
            else if (actionKey.Equals("-TouchAutors") || actionKey.Equals("-AutorsTouch"))
            {
                Debug.Log("entry autors menu");
                sceneChanger.OpenAutorsMenuItem();
                sceneChanger.CloseBrainPanel();
                lineDrawer.DeleteConnection(newNet, newNet.netIndex);
            }
            else if (actionKey.Equals("-TouchHelp") || actionKey.Equals("-HelpTouch"))
            {
                Debug.Log("entry help menu");  
                sceneChanger.OpenHelpMenuItem();
                sceneChanger.CloseBrainPanel();
                lineDrawer.DeleteConnection(newNet, newNet.netIndex);
            }
            else if (actionKey.Equals("-TouchExit") || actionKey.Equals("-ExitTouch"))
            {
                Debug.Log("exit the game");
                Application.Quit();
                lineDrawer.DeleteConnection(newNet, newNet.netIndex);
            }
            else if (newNet.neighboors.Count > 4)
            {
                lineDrawer.pointsToConnect.Clear();
                lineDrawer.DeleteConnection(newNet, newNet.netIndex);
            }
        }
    }
}
