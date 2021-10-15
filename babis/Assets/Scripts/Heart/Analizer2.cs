using System;
using System.Security.Cryptography;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Analizer2 : MonoBehaviour
{
    [SerializeField] private LineDrawer lineDrawer;
    [SerializeField] private int coursePoints;
    [SerializeField] private ConnectionsMethods methods;
    [SerializeField] private GameObject currEyes;
    [SerializeField] private List<Sprite> eyesVariation;
    [SerializeField] private JournalWritings journalWrite;
    [SerializeField] private Animation animRenderer;
    [SerializeField] private RectTransform rectTransform;

    public void SetNativeSize()
    {
        rectTransform.localScale = new Vector2(.5f, .5f);
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
                    //spriteRenderer.sprite = eyesVariation[Random.Range(0, eyesVariation.Count)];
                    methods.ShowDescription(objs[(dominante + 1) % 2].description);
                }
                else if (objs[dominante].type == BrainDot.dotType.special)
                {
                    if (objs[(dominante + 1) % 2].scoreInc != 0)
                    {
                        methods.ScoreInc(objs[(dominante + 1) % 2].scoreInc);
                        journalWrite.combinations.Add(objs[dominante].name + " + " + objs[(dominante + 1) % 2].name
                                                      + " = " + objs[(dominante + 1) % 2].scoreInc);
                        animRenderer.Play();
                    }
                }
                else if (objs[dominante].type == BrainDot.dotType.drink)
                {
                    methods.SetMulti(objs[(dominante + 1) % 2].multi);
                    journalWrite.combinations.Add(objs[dominante].name + " + " + objs[(dominante + 1) % 2].name
                                                  + " = x" + objs[(dominante + 1) % 2].multi);
                    animRenderer.Play();
                }
                lineDrawer.DeleteExistingNet(newNet, newNet.netIndex);
            }
        }
    }
}
