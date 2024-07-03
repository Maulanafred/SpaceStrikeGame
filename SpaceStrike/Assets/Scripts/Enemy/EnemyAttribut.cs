using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyAttribut : MonoBehaviour
{

    public GameObject vfxdeath;

    public GameObject vfxHit;

    public GameObject sounddeath;
    private Transform transform;
    public static EnemyAttribut instance;
    public int healthenemy = 100;



    private EnemyBasicAttack enemyBasicAttack;

    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
        instance = this;
        enemyBasicAttack = GetComponent<EnemyBasicAttack>(); // Dapatkan referensi ke skrip EnemyBasicAttack
    }

    // Update is called once per frame
    void Update()
    {
        if (healthenemy <= 0)
        {
            if (SceneManager.GetActiveScene().name == "Level1")
            {
                ScoreManager.instance.AddScore(10);
  
            }
            if(SceneManager.GetActiveScene().name == "Level2")
            {
                ScoreManager2.instance.EnemyDefeated();

            }
            
            Destroy(this.gameObject);
            SpawnDeathVFX();


            
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BasicAttack"))
        {
            GameObject hitvfx = Instantiate(vfxHit, transform.position, Quaternion.identity);
            Destroy(hitvfx, 4f);
            ReduceHealthEnemy(50);
        }
        if (other.CompareTag("Skill4"))
        {
            GameObject hitvfx = Instantiate(vfxHit, transform.position, Quaternion.identity);
            Destroy(hitvfx, 4f);
            ReduceHealthEnemy(200);
        }

        if (other.CompareTag("Skill3"))
        {
            GameObject hitvfx = Instantiate(vfxHit, transform.position, Quaternion.identity);
            Destroy(hitvfx, 4f);
            ReduceHealthEnemy(300);
        }

        if (other.CompareTag("Ultimate"))
        {
            GameObject hitvfx = Instantiate(vfxHit, transform.position, Quaternion.identity);
            Destroy(hitvfx, 4f);
            ReduceHealthEnemy(300);
        }
    }

    public void ReduceHealthEnemy(int hp)
    {
        healthenemy -= hp;
    }

    public void SpawnDeathVFX()
    {
        GameObject deathvfx = Instantiate(vfxdeath, transform.position, Quaternion.identity);
        Destroy(deathvfx, 4f);

        GameObject sfxdeathvfx = Instantiate(sounddeath, transform.position, Quaternion.identity);
        Destroy(sfxdeathvfx, 4f);
    }
}
