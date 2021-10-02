using System.Collections.Generic;
using UnityEngine;

public class LineDrawer : MonoBehaviour
{
    [SerializeField] private List<GameObject> connectionLines;
    [SerializeField] private List<GameObject> pointsToConnect;
    void Start()
    {
        
    }

    void Update()
    {
        if (pointsToConnect.Count >= 2)
        {
            if(pointsToConnect[0] != null && pointsToConnect[1] != null) LineCaster(pointsToConnect[0].transform, pointsToConnect[1].transform);
        }
    }

    void LineCaster(Transform origin, Transform destination)
    {
        Debug.DrawLine(origin.position,destination.position, Color.cyan);
    }
}
