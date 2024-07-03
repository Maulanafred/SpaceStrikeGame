using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShortcutManagement;
using UnityEngine;

public class BossUltimate : MonoBehaviour
{
    private BoxCollider col;
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<BoxCollider>();

        col.enabled = false;

        StartCoroutine(EnableBurst());

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator EnableBurst(){
        yield return new WaitForSeconds(6.5f);

        col.enabled = true;

        yield return new WaitForSeconds(1f);

        Destroy(this.gameObject);
    }
}
