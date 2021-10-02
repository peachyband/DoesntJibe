using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MindCell : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private float xAttitude, yAttitude;
    [SerializeField] private float speed;
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
    }

    void MoveBetweenPoints(Vector2 origin, Vector2 destination)
    {
        if (_moveDir == 1) currPos = destination;
        else if (_moveDir == -1) currPos = origin;

        transform.position = Vector2.MoveTowards(transform.position, currPos, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, currPos) <= 0.01f) _moveDir *= -1;
    }

    public void OnBeginDrag(PointerEventData data)
    {
        
    }
    public void OnDrag(PointerEventData data)
    {
        
    }
    public void OnEndDrag(PointerEventData data)
    {
        
    }
}
