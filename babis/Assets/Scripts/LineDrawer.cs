using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LineDrawer : MonoBehaviour
{
    public class NeighboorNet : MonoBehaviour
    {
        public List<GameObject> neighboors;
        public int netIndex;
        public LineRenderer _connection;
        private void Awake()
        {
            _connection = gameObject.AddComponent<LineRenderer>();
            _connection.startColor = Color.gray;
            _connection.endColor = Color.gray;
            _connection.startWidth = 0.025f;
            _connection.endWidth = 0.05f;
            _connection.sortingOrder = 1;
        }
        public void SetupLine(List<GameObject> points)
        {
            _connection.positionCount = neighboors.Count;
            neighboors = points.ToList();
        }
        private void Update()
        {
            for (int indx = 0; indx < neighboors.Count; indx++)
            {
                _connection.SetPosition(indx, neighboors[indx].transform.position);
            }
        }
    }

    public MindGenerator mindGenerator;
    public List<GameObject> connectionLines;
    public List<GameObject> pointsToConnect;
    public GameObject netContainer;
    public Material lineMat;
    public GameObject CreateNewNet(List<GameObject> points, int netIndex)
    {
        GameObject newConnection = new GameObject();
        newConnection.name = "net" + netIndex;
        newConnection.transform.parent = netContainer.transform;
        NeighboorNet netConfig = newConnection.AddComponent<NeighboorNet>();
        netConfig.neighboors = points.ToList();
        netConfig.SetupLine(points);
        netConfig.netIndex = netIndex;
        netConfig._connection.material = lineMat;
        pointsToConnect.Clear();
        return newConnection;
    }
    public void ContinueExistingNet(GameObject point, int netIndex)
    {
        NeighboorNet netConfig = connectionLines[netIndex].GetComponent<NeighboorNet>();
        point.transform.parent = connectionLines[netIndex].transform;
        netConfig.neighboors.Add(point);
        netConfig.SetupLine(netConfig.neighboors);
    }

    public void DeleteExistingNet(NeighboorNet net, int netIndex)
    {
        connectionLines.RemoveAt(netIndex);
        net.neighboors.ForEach(neighboor =>
        {
            mindGenerator.objsName.Add(neighboor.name);
        });
        Destroy(net.transform.gameObject);
    }

    public void DeleteConnection(NeighboorNet net, int netIndex)
    {
        connectionLines.RemoveAt(netIndex);
        net.neighboors.ForEach(neighboor =>
        {
            neighboor.gameObject.transform.parent = null;
        });
        Destroy(net.transform.gameObject);
    }
}
