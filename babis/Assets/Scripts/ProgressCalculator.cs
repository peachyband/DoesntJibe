using System.Collections.Generic;
using UnityEngine;

public class ProgressCalculator : MonoBehaviour
{
    public float progressScale;
    private RectTransform _rectTransform;
    [SerializeField] private List<AudioClip> audioClips;
    [SerializeField] private AudioSource audioSource;
    private void Start()
    {
        _rectTransform = GetComponent (typeof (RectTransform)) as RectTransform;
    }

    private void Update()
    {
        progressScale = Mathf.Clamp(progressScale, 0, 100);
        _rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, progressScale * 2);
        if (!audioSource.isPlaying)
        {
            audioSource.clip = audioClips[Random.Range(0, audioClips.Count)];
            audioSource.Play();
        }
    }
}
