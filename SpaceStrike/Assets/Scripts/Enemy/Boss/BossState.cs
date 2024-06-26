using System.Collections;
using System.Collections.Generic;
using Unity.Profiling;
using UnityEditor;
using UnityEngine;

public class BossState : MonoBehaviour
{
    [Header("Basic Attack")]

    public GameObject basicAttackVFX;
    public Transform[] basicAttack;

    public Transform[] missleAttack;

    public GameObject missleVFX;

    public Transform ultimate;

    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AttackBasic());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator AttackBasic(){
        while(true){

            GameObject basic = Instantiate(basicAttackVFX, basicAttack[0].position, Quaternion.Euler(-90,0,0));
            GameObject basic1 = Instantiate(basicAttackVFX, basicAttack[1].position, Quaternion.Euler(-90,0,0));
            GameObject basic2 = Instantiate(basicAttackVFX, basicAttack[2].position, Quaternion.Euler(-90,0,0) );
            yield return new WaitForSeconds(3f);
        }
    }

    private IEnumerator MissleSkill(){
        while(true){

            GameObject skill1 = Instantiate(missleVFX, basicAttack[0].position, Quaternion.Euler(90,0,0));
            GameObject skill2 = Instantiate(missleVFX, basicAttack[1].position, Quaternion.Euler(90,0,0));
        }
    }
}
