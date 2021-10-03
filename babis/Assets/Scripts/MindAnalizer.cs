using System.Security.Cryptography;
using UnityEngine;

public class MindAnalizer : MonoBehaviour
{
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
            if (actionKey.Equals("-MopTea"))
            {
                Debug.Log("sheeesh");
                //TODO:
                //1.make a move - incomplete
                //2.delete net - incomplete
            }
        }
    }
}
