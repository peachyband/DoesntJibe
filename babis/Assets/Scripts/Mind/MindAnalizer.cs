using System.Security.Cryptography;
using UnityEngine;

public class MindAnalizer : MonoBehaviour
{
    [SerializeField] private LineDrawer lineDrawer;
    [SerializeField] private int coursePoints;
    [SerializeField] private SceneChanger sceneChanger;
    private void Update()
    {
        foreach (Transform child in transform)
        {
            LineDrawer.NeighboorNet newNet = child.GetComponent<LineDrawer.NeighboorNet>();
            string actionKey = new string('-', 1);
            newNet.neighboors.ForEach(neighboor => { actionKey += neighboor.name.ToString(); });
            if (actionKey.Equals("-CourseworkTea") || actionKey.Equals("-TeaCoursework"))
            {
                Debug.Log("sheeesh");
                //TODO:
                //1.make a move - incomplete
                //2.delete net - incomplete
                lineDrawer.DeleteExistingNet(newNet, newNet.netIndex);
            }
            else if (actionKey.Equals("-CourseworkKeyboard"))
            {
                coursePoints += 1;
                lineDrawer.DeleteExistingNet(newNet, newNet.netIndex);
            }
            else if (actionKey.Equals("-TouchPlay"))
            {
                Debug.Log("start game");
                StartCoroutine(sceneChanger.ChangeScene(1, 3));
                lineDrawer.DeleteConnection(newNet, newNet.netIndex);
            }
            else if (actionKey.Equals("-TouchAutors"))
            {
                Debug.Log("entry autors menu");
                sceneChanger.OpenAutorsMenuItem();
                lineDrawer.DeleteConnection(newNet, newNet.netIndex);
            }
            else if (actionKey.Equals("-TouchHelp"))
            {
                Debug.Log("entry help menu");  
                sceneChanger.OpenHelpMenuItem();
                lineDrawer.DeleteConnection(newNet, newNet.netIndex);
            }
            else if (actionKey.Equals("-TouchExit"))
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
