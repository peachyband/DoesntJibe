using System.Collections.Generic;
using UnityEngine;

public class ProgressCalculator : MonoBehaviour
{
    public float progressScale = 1;
    private RectTransform _rectTransform;
    [SerializeField] private Transform heart;
    [SerializeField] private SceneChanger sceneChanger;
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

        if (progressScale >= 20)
        {
            heart.gameObject.SetActive(true);
        }
        if (progressScale >= 100)
        {
            sceneChanger.ChangeScene(1, 1);
        }
        else if (progressScale <= 0)
        {
            sceneChanger.ChangeScene(1, 1);
        }
    }
}
