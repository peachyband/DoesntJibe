using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MindCell : MonoBehaviour
{
    public float xAttitude, yAttitude;
    public float speed;
    public Material lineMat;
    public LineDrawer lineManager;
    public Text uiName;
    public int netCount;
    private Vector2 aSidePos, bSidePos, currPos;
    private int _moveDir = 1;
    private int compareOne, compareTwo;
    
    private void Start()
    {
        aSidePos = new Vector2(transform.position.x - xAttitude, transform.position.y - yAttitude);
        bSidePos = new Vector2(transform.position.x + xAttitude, transform.position.y + yAttitude);
    }

    private void Update()
    {
        MoveBetweenPoints(aSidePos, bSidePos);
        MouseInput();
    }

    void MoveBetweenPoints(Vector2 origin, Vector2 destination)
    {
        if (_moveDir == 1) currPos = destination;
        else if (_moveDir == -1) currPos = origin;

        transform.position = Vector2.MoveTowards(transform.position, currPos, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, currPos) <= 0.01f) _moveDir *= -1;
    }

    private void OnMouseDown()
    {
        LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = lineMat;
        lineRenderer.startColor = Color.yellow;
        lineRenderer.endColor = Color.yellow;
        lineRenderer.startWidth = 0.02f;
        lineRenderer.endWidth = 0.02f;
        lineRenderer.positionCount = 2;
        lineManager.pointsToConnect.Add(gameObject);
        compareOne = netCount;
    }

    private void OnMouseDrag()
    {
        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        Vector3 pointerFollowed = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, pointerFollowed);
    }
    private void MouseInput()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (!gameObject.GetComponent<LineRenderer>()) return;
            Destroy(gameObject.GetComponent<LineRenderer>());
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider)
            {
                compareTwo = hit.transform.gameObject.GetComponent<MindCell>().netCount;
                int netNum = lineManager.connectionLines.Count;
                //making new net
                if (compareTwo == compareOne)
                {
                    lineManager.pointsToConnect.Add(hit.transform.gameObject);
                    List<GameObject> points = lineManager.pointsToConnect.ToList();
                    points[0].gameObject.GetComponent<MindCell>().netCount = netNum;
                    points[1].gameObject.GetComponent<MindCell>().netCount = netNum;
                    lineManager.connectionLines.Add(lineManager.CreateNewNet(points, netNum));
                    points[0].gameObject.transform.parent = lineManager.connectionLines[netNum].transform;
                    points[1].gameObject.transform.parent = lineManager.connectionLines[netNum].transform;
                    Debug.Log("chupapi " + points[0].name + " munyanya " + points[1].name);
                }
                //continue current net
                else if (compareTwo != compareOne)
                {
                    netNum = lineManager.pointsToConnect[0].gameObject.GetComponent<MindCell>().netCount;
                    lineManager.ContinueExistingNet(hit.transform.gameObject, netNum);
                    hit.transform.gameObject.GetComponent<MindCell>().netCount = netNum;
                }
            }
        }
    }
}
