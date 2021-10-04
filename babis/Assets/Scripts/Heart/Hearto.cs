using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Hearto : MonoBehaviour
{

    [SerializeField] Animator anim;
    private float heartStat = 0;
    [SerializeField] Text heartText;
    private bool allGOOD = false;
    [SerializeField] private float decrMult = 1;
    [SerializeField] private int incr = 5;

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
            if (heartStat == 100)
            {
                allGOOD = true;
                StartCoroutine("konez");
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

    IEnumerator konez() 
    {
        if (heartText != null)
            heartText.text = "WELL DONE!!!";
        yield return new WaitForSeconds(1.5f);
        Destroy(this.gameObject);
    }

    private void OnMouseDown()
    {
        if (!allGOOD)
            heartStat += incr;
    }
}
