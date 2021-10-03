using System.Security.Cryptography;
using UnityEngine;

public class MindAnalizer : MonoBehaviour
{
    [SerializeField] private LineDrawer lineDrawer;
    [SerializeField] private int coursePoints;
    private void Update()
    {
        foreach (Transform child in transform)
        {
            LineDrawer.NeighboorNet newNet = child.GetComponent<LineDrawer.NeighboorNet>();
            string actionKey = new string('-', 1);
            newNet.neighboors.ForEach(neighboor =>
            {
                actionKey += neighboor.name.ToString();
            });
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
            //else if(newNet.neighboors.Count > 3) lineDrawer.DeleteConnection(newNet, newNet.netIndex);
        }
    }
}
