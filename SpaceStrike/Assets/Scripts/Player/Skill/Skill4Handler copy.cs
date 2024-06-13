using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill4Handler : MonoBehaviour
{

    private SphereCollider col;
    // Start is called before the first frame update
    void Start()
    {

        col = GetComponent<SphereCollider>();

        col.enabled = false;

        StartCoroutine(Delay());

        
        
    }



    

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Delay(){
        yield return new WaitForSeconds(2f);
        col.enabled = true;
        yield return new WaitForSeconds(1f);
        col.enabled = false;

    }



}
