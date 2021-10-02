using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.EventSystems;

public class MindCell : MonoBehaviour
{
    [SerializeField] private float xAttitude, yAttitude;
    [SerializeField] private float speed;
    [SerializeField] private Material lineMat;
    [SerializeField] private LineDrawer lineManager;
    [SerializeField] private int netCount;
    private Vector2 aSidePos, bSidePos, currPos;
    private int _moveDir = 1;

    private void Start()
    {
        aSidePos = new Vector2(transform.position.x - xAttitude, transform.position.y - yAttitude);
        bSidePos = new Vector2(transform.position.x + xAttitude, transform.position.y + yAttitude);
    }

    private void Update()
    {
        MoveBetweenPoints(aSidePos, bSidePos);
        MouseUp();
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
        lineRenderer.startWidth = 0.01f;
        lineRenderer.endWidth = 0.01f;
        lineRenderer.positionCount = 2;
        lineManager.pointsToConnect.Add(gameObject);
    }

    private void OnMouseDrag()
    {
        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        Vector3 pointerFollowed = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, pointerFollowed);
    }
    // private void OnMouseUp()
    // {
    //     if(!gameObject.GetComponent<LineRenderer>()) return;
    //     Destroy(gameObject.GetComponent<LineRenderer>());
    //     lineManager.pointsToConnect.Add(gameObject);    
    //     List<GameObject> points = lineManager.pointsToConnect.ToList();
    //     lineManager.connectionLines.Add(lineManager.CreateNewNet(points));
    //     Debug.Log("chupapi " + points[0].name + " munyanya " + points[1].name);
    //     //lineManager.pointsToConnect.Clear();
    // }

    private void MouseUp()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (!gameObject.GetComponent<LineRenderer>()) return;
            Destroy(gameObject.GetComponent<LineRenderer>());
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null)
            {
                lineManager.pointsToConnect.Add(hit.transform.gameObject);
                List<GameObject> points = lineManager.pointsToConnect.ToList();
                lineManager.connectionLines.Add(lineManager.CreateNewNet(points));
                Debug.Log("chupapi " + points[0].name + " munyanya " + points[1].name);
                //lineManager.pointsToConnect.Clear();
            }
        }
    }
}
