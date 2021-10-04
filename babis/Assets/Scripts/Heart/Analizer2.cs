using System;
using System.Security.Cryptography;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Analizer2 : MonoBehaviour
{
    [SerializeField] private LineDrawer lineDrawer;
    [SerializeField] private int coursePoints;
    [SerializeField] private ConnectionsMethods methods;
    [SerializeField] private GameObject currEyes;
    [SerializeField] private List<Sprite> eyesVariation;
    private SpriteRenderer _spriteRenderer;
    private void Awake()
    {
        _spriteRenderer = currEyes.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        foreach (Transform child in transform)
        {
            LineDrawer.NeighboorNet newNet = child.GetComponent<LineDrawer.NeighboorNet>();
            List<BrainDot> objs = new List<BrainDot>();
            newNet.neighboors.ForEach(neighboor => { objs.Add(neighboor.GetComponent<MindCell>().dot); });
             int dominante = BrainDot.GetDominante(objs[0].type, objs[1].type);

            if (dominante >= 0)
            {
                if (objs[dominante].type == BrainDot.dotType.eyes)
                {
                    Debug.Log(objs[dominante].name + "+" + objs[(dominante + 1) % 2].name);
                    _spriteRenderer.sprite = eyesVariation[Random.Range(0, eyesVariation.Count)];
                    methods.ShowDescription(objs[(dominante + 1) % 2].description);
                }

                else if (objs[dominante].type == BrainDot.dotType.special)
                {
                    if (objs[(dominante + 1) % 2].scoreInc != 0)
                        methods.ScoreInc(objs[(dominante + 1) % 2].scoreInc);
                }

                else if (objs[dominante].type == BrainDot.dotType.drink)
                {
                    
                        methods.SetMulti(3);
                }

                lineDrawer.DeleteExistingNet(newNet, newNet.netIndex);
                //do smth
            }

            //string actionKey = new string('-', 1);
            //newNet.neighboors.ForEach(neighboor => { actionKey += neighboor.name.ToString(); });



            //if (actionKey.Equals("-CourseworkTea") || actionKey.Equals("-TeaCoursework"))
            //{
            //    Debug.Log("sheeesh");
            //    //TODO:
            //    //1.make a move - incomplete
            //    //2.delete net - incomplete
            //    lineDrawer.DeleteExistingNet(newNet, newNet.netIndex);
            //}
            //else if (actionKey.Equals("-CourseworkKeyboard"))
            //{
            //    coursePoints += 1;
            //    lineDrawer.DeleteExistingNet(newNet, newNet.netIndex);
            //}





            //else if (actionKey.Equals("-TouchPlay"))
            //{
            //    Debug.Log("start game");
            //    lineDrawer.DeleteConnection(newNet, newNet.netIndex);
            //}
            //else if (actionKey.Equals("-TouchAutors"))
            //{
            //    Debug.Log("entry autors menu");
            //    lineDrawer.DeleteConnection(newNet, newNet.netIndex);
            //}
            //else if (actionKey.Equals("-TouchHelp"))
            //{
            //    Debug.Log("entry help menu");
            //    lineDrawer.DeleteConnection(newNet, newNet.netIndex);
            //}
            //else if (actionKey.Equals("-TouchExit"))
            //{
            //    Debug.Log("exit the game");
            //    lineDrawer.DeleteConnection(newNet, newNet.netIndex);
            //}
            //else if (newNet.neighboors.Count > 4)
            //{
            //    lineDrawer.pointsToConnect.Clear();
            //    lineDrawer.DeleteConnection(newNet, newNet.netIndex);
            //}
        }
    }
}
