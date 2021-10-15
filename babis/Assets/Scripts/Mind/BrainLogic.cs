using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BrainLogic : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Image readableImage;
    [SerializeField] private Text readableText;
    [SerializeField] private List<string> mindOlogue;
    [SerializeField] private List<Sprite> brainEmo;
    [SerializeField] private int currLine;
    [SerializeField] private Transform bTransform;
    
    public void OnPointerDown(PointerEventData eventData)
    {
        if (currLine < mindOlogue.Count - 1)
        {
            currLine += 1;
            readableText.text = mindOlogue[currLine];
            readableImage.sprite = brainEmo[Random.Range(0, brainEmo.Count)];
        }
        else Destroy(bTransform.gameObject);
    }
    
    
}
