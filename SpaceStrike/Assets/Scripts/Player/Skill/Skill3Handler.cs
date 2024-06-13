
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Skill3Handler : MonoBehaviour
{

    private SphereCollider col;
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<SphereCollider>();
        col.enabled = false;
        //col.enable = false;

        StartCoroutine(DelayCollider());


        
    }



    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator DelayCollider(){
        yield return new WaitForSeconds(1.6f);

        col.enabled = true;

    }
}
