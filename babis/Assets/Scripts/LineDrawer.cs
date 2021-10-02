using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LineDrawer : MonoBehaviour
{
    public class NeighboorNet : MonoBehaviour
    {
        public List<GameObject> neighboors;
        public int netIndex;
        private LineRenderer _connection;
        

        private void Awake()
        {
            _connection = GetComponent<LineRenderer>();
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
    
    public List<NeighboorNet> connectionLines;
    public List<GameObject> pointsToConnect;
    public NeighboorNet CreateNewNet(List<GameObject> points)
    {
        NeighboorNet newConnection = gameObject.AddComponent<NeighboorNet>();
        newConnection.neighboors = points.ToList();
        newConnection.SetupLine(points);
        pointsToConnect.Clear();
        return newConnection;
    }
    public void ContinueExistingNet(GameObject point, int netIndex)
    {
        connectionLines[netIndex].neighboors.Add(point);
        connectionLines[netIndex].SetupLine(connectionLines[netIndex].neighboors);
    }
    private void Start()
    {
        // connectionLines.Add(CreateNewNet(pointsToConnect.ToList()));
    }
}
