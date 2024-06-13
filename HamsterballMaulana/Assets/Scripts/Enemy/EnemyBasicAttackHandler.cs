using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasicAttackHandler : MonoBehaviour
{
    private Transform tf;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BasicAttack());


        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator BasicAttack(){
        while (true)
        {
            this.transform.Translate(Vector3.down * 50 * Time.deltaTime);
            yield return null; // Wait for the next frame
        }
    }

}
