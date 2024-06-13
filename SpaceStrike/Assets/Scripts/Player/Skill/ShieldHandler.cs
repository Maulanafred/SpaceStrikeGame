using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShieldHandler : MonoBehaviour
{

    private SphereCollider sc;

    // Start is called before the first frame update
    void Start()
    {
        sc = GetComponent<SphereCollider>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("BasicAttackEnemy")){
            Destroy(other.gameObject);
            Debug.Log("basic kena shield");
        }

    }
}
