using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BasicAttackBossHandler : MonoBehaviour
{

    public float vfxSpeed;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Destroy());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = this.transform.position + Vector3.back * vfxSpeed * Time.deltaTime;
    }

    IEnumerator Destroy(){

        yield return new WaitForSeconds(10f);
        Destroy(this.gameObject);
    }
}
