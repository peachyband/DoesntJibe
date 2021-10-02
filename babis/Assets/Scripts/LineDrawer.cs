using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LineDrawer : MonoBehaviour
{
    public class NeighboorNet : MonoBehaviour
    {
        private LineRenderer _connection;
        public List<GameObject> neighboors;

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
    
    [SerializeField] private List<NeighboorNet> connectionLines;
    [SerializeField] private List<GameObject> pointsToConnect;

    public NeighboorNet CreateNewNet(List<GameObject> points)
    {
        NeighboorNet newConnection = gameObject.AddComponent<NeighboorNet>();
        newConnection.neighboors = points.ToList();
        newConnection.SetupLine(points);
        return newConnection;
    }

    private void Start()
    {
        connectionLines.Add(CreateNewNet(pointsToConnect.ToList()));
    }
}
