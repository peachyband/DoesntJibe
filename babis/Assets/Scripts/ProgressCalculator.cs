using UnityEngine;

public class ProgressCalculator : MonoBehaviour
{
    [SerializeField] private float progressScale;
    private RectTransform _rectTransform;
    private void Start()
    {
        _rectTransform = GetComponent (typeof (RectTransform)) as RectTransform;
    }

    private void Update()
    {
        _rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, progressScale * 2);
    }
}
