using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MindCell : MonoBehaviour
{
    [SerializeField] private float xAttitude, yAttitude;
    [SerializeField] private float speed;
    private Vector2 aSidePos, bSidePos;

    private void Start()
    {
        aSidePos = new Vector2(transform.position.x - xAttitude, transform.position.y - yAttitude);
        bSidePos = new Vector2(transform.position.x + xAttitude, transform.position.y + yAttitude);
    }

    void Update()
    {
        transform.position = Vector2.Lerp(aSidePos, bSidePos, speed * Time.deltaTime);
    }
}
