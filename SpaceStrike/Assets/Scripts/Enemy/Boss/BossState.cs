using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossState : MonoBehaviour
{
    [Header("Spawn Enemy")]
    public Transform[] spawnEnemy;
    public GameObject enemy;
    public float enemySpeed;

    [Header("Basic Attack")]
    public GameObject basicAttackVFX;
    public Transform[] basicAttack;

    public GameObject soundBasic;

    [Header("Missile Skill")]
    public Transform[] missileAttack;
    public GameObject missileVFX;

    [Header("Ultimate")]
    public GameObject ultimateVFX;
    public Transform ultimate;
    public float ultimateSpeed;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AttackBasic());
        StartCoroutine(MissileSkill());
        StartCoroutine(Ultimate());
        StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator AttackBasic()
    {
        while (true)
        {
            Instantiate(basicAttackVFX, basicAttack[0].position, Quaternion.Euler(0, 90, 90));
            Instantiate(basicAttackVFX, basicAttack[1].position, Quaternion.Euler(0, 90, 90));
            Instantiate(basicAttackVFX, basicAttack[2].position, Quaternion.Euler(0, 90, 90));

            GameObject basicbosssfx = Instantiate(soundBasic, basicAttack[1].position, Quaternion.Euler(0, 90, 90));

            Destroy(basicbosssfx,3f);
            yield return new WaitForSeconds(3f);
        }
    }

    private IEnumerator MissileSkill()
    {
        while (true)
        {
            Instantiate(missileVFX, missileAttack[0].position, Quaternion.Euler(-90, 0, 0));
            Instantiate(missileVFX, missileAttack[1].position, Quaternion.Euler(-90, 0, 0));
            yield return new WaitForSeconds(10f);
        }
    }

    private IEnumerator Ultimate()
    {
        while (true)
        {
            GameObject skill1 = Instantiate(ultimateVFX, ultimate.position, Quaternion.identity);
            StartCoroutine(MoveVFXUltimate(skill1));
            yield return new WaitForSeconds(10f);
        }
    }

    private IEnumerator MoveVFXUltimate(GameObject vfx)
    {
        float elapsedTime = 0f;
        while (vfx != null && elapsedTime <= 4f)
        {
            vfx.transform.Translate(Vector3.back * ultimateSpeed * Time.deltaTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            // Choose a random spawn point from the array
            int randomIndex = Random.Range(0, spawnEnemy.Length);

            // Instantiate the enemy at the chosen spawn point
            GameObject spawnedEnemy = Instantiate(enemy, spawnEnemy[randomIndex].position, Quaternion.Euler(0,180,0));

            // Start movement coroutine for the spawned enemy
            StartCoroutine(MovementEnemy(spawnedEnemy));

            Destroy(spawnedEnemy,20f);

            // Wait for a random time between 2 and 3 seconds
            yield return new WaitForSeconds(Random.Range(2f, 3f));
        }
    }

    private IEnumerator MovementEnemy(GameObject spawnedEnemy)
    {
        while (spawnedEnemy != null)
        {
            // Move the spawned enemy forward along its local z-axis
            spawnedEnemy.transform.Translate(Vector3.forward * enemySpeed * Time.deltaTime);
            yield return null;
        }
    }
}
