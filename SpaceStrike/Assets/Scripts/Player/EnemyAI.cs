using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{   
    public NavMeshAgent enemyAI;
    public Transform player;
    public float jarakKejar = 10f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {   
        float jarak =  Vector3.Distance(player.position, transform.position);
        if(jarak <= jarakKejar){
            enemyAI.SetDestination(player.position);
        }
        else{
            enemyAI.SetDestination(transform.position);
        }
    }

    public void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            ScoreManager.instance.AddScore(10);
        }
    }

}
