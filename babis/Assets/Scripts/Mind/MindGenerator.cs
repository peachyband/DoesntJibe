using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MindGenerator : MonoBehaviour
{
    [SerializeField] private List<GameObject> cells;
    [SerializeField] private GameObject cellPrefab;
    public List<BrainDot> objsName;
    [SerializeField] private LineDrawer lineDrawer;
    [SerializeField] private Transform brain; 
    [SerializeField] private Vector2 brainSize;
    [SerializeField] private float mindSpeed;
    GameObject GenerateOne()
    {
        GameObject newCell = Instantiate(cellPrefab, PickAPoint(brain,brainSize), Quaternion.identity);
        MindCell cellControl = newCell.GetComponent<MindCell>();
        int rand = Random.Range(0, objsName.Count);
        BrainDot.Copy(objsName[rand], ref cellControl.dot);
        newCell.name = cellControl.dot.name;
        cellControl.uiName.text = newCell.name;
        objsName.RemoveAt(rand);
        cellControl.lineManager = lineDrawer;
        cellControl.speed = Random.Range(0.05f, 0.2f);
        cellControl.xAttitude = Random.Range(-2f, 2f);
        cellControl.yAttitude = Random.Range(-2f, 2f);
        return newCell;
    }

    private void Start()
    {
        StartCoroutine(Thoughts());
    }

    Vector2 PickAPoint(Transform spawnLocation, Vector2 locationSize)
    {
        Vector2 pos = (Vector2) spawnLocation.position + new Vector2(
            Random.Range(-locationSize.x / 2 + 2, locationSize.x / 2 - 2),
            Random.Range(-locationSize.y / 2 + 2, locationSize.y / 2 - 2));
        return pos;
    }

    IEnumerator Thoughts()
    {
        while (objsName.Count > 0)
        {
            yield return new WaitForSeconds(mindSpeed);
            cells.Add(GenerateOne());
        }
    }
}
