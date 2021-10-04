using UnityEngine;

public class ProgressCalculator : MonoBehaviour
{
    public float progressScale;
    private RectTransform _rectTransform;
    private void Start()
    {
        _rectTransform = GetComponent (typeof (RectTransform)) as RectTransform;
    }

    private void Update()
    {
        progressScale = Mathf.Clamp(progressScale, 0, 100);
        _rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, progressScale * 2);
    }
}
