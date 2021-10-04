using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Hearto : MonoBehaviour
{

    [SerializeField] Animator anim;
    private float heartStat = 50;
    [SerializeField] Text heartText;
    private bool allGOOD = false;
    [SerializeField] private float decrMult = 1;
    [SerializeField] private int incr = 5;
    [SerializeField] private Transform heartFailure;

    [SerializeField] private SceneChanger sceneChanger;
    // Start is called before the first frame update
    void Start()
    {
        if (this.GetComponent<Animator>())
            anim = this.GetComponent<Animator>();
        anim.speed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!allGOOD)
        {
            if (heartStat >= 99 || heartStat <= 1)
            {
                allGOOD = true;
                TheEnd();
                return;
            }
            heartStat -= Time.deltaTime * decrMult;

            heartStat = Mathf.Clamp(heartStat, 0, 100);
            if (heartText != null)
                heartText.text = "Heart status: " + heartStat.ToString("0");

            

            //if (Input.GetKeyDown(KeyCode.R))
            ///{
                //heartStat += 5;
                
            //}

            if (this.GetComponent<Animator>())
                anim.speed = heartStat / 100;
        }
    }

    void TheEnd() 
    {
        heartFailure.gameObject.SetActive(true);
    }

    private void OnMouseDown()
    {
        if (!allGOOD)
            heartStat += incr;
    }
}
