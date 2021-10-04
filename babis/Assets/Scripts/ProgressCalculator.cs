using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressCalculator : MonoBehaviour
{
    public float progressScale = 1;
    public int multipier = 1;
    [SerializeField] private Text mulText;
    private RectTransform _rectTransform;
    [SerializeField] private Transform heart;
    [SerializeField] private SceneChanger sceneChanger;
    [SerializeField] private List<AudioClip> audioClips;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private float cooldown = 1f;
    private void Start()
    {
        _rectTransform = GetComponent (typeof (RectTransform)) as RectTransform;
    }

    private void Update()
    {

        if (multipier > 1)
        {
            mulText.text = "x" + multipier.ToString();
            StartCoroutine("coolDown");

        }
        else mulText.text = "";

        progressScale = Mathf.Clamp(progressScale, 0, 100);
        _rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, progressScale * 2);
        if (!audioSource.isPlaying)
        {
            audioSource.clip = audioClips[UnityEngine.Random.Range(0, audioClips.Count)];
            audioSource.Play();
        }

        if (progressScale >= 20)
        {
            heart.gameObject.SetActive(true);
        }
        if (progressScale >= 100)
        {
            sceneChanger.ChangeScene(3, 0);
        }
        else if (progressScale <= 0)
        {
            sceneChanger.ChangeScene(0, 0);
        }
    }

    IEnumerator coolDown() 
    {
        yield return new WaitForSeconds(cooldown);
        multipier = 1;

    }
}
