using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class BossAttribut : MonoBehaviour
{

    public UnityEvent bossdeath;

    public Transform deadspawn;
    public Image bossHP;
    public float hpBoss = 1000f;
    public float maxHpBoss = 1000f;
    public float regenAmount = 5f; // Amount of HP regenerated per interval
    public float regenInterval = 1f; // Interval for regeneration in seconds

    private bool isRegenerating = true;

    private bool bossDeath = false;

    public GameObject vfxHit;

    public GameObject destroyVFX;

    public GameObject mainCamera;

    public GameObject[] UI;

    public GameObject UIWIN;

    public GameObject uiResult;

    public GameObject cutSceneCamera;

    public GameObject objectBoss;
    void Start()
    {
        // Initialize the boss HP bar
        bossHP.fillAmount = hpBoss / maxHpBoss;

        // Start the HP regeneration coroutine
        StartCoroutine(RegenerateHP());
    }

    void Update()
    {
        // Update the HP bar
        bossHP.fillAmount = hpBoss / maxHpBoss;

        // For testing: Reduce and increase HP using keys
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReduceHP(100f);
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            IncreaseHP(50f);
        }
    }

    void OnTriggerEnter(Collider other){
        if (other.CompareTag("BasicAttack"))
        {
            GameObject hitvfx = Instantiate(vfxHit, transform.position, Quaternion.identity);
            Destroy(hitvfx, 4f);
            ReduceHP(2f);
        }
        if (other.CompareTag("Skill4"))
        {
            GameObject hitvfx = Instantiate(vfxHit, transform.position, Quaternion.identity);
            Destroy(hitvfx, 4f);
            ReduceHP(100f);
        }

        if (other.CompareTag("Skill3"))
        {
            GameObject hitvfx = Instantiate(vfxHit, transform.position, Quaternion.identity);
            Destroy(hitvfx, 4f);
            ReduceHP(200f);
        }

        if (other.CompareTag("Ultimate"))
        {
            ReduceHP(500f);
            GameObject hitvfx = Instantiate(vfxHit, transform.position, Quaternion.identity);
            Destroy(hitvfx, 4f);
        }
    }

    public void ReduceHP(float amount)
    {
        hpBoss -= amount;
        hpBoss = Mathf.Clamp(hpBoss, 0, maxHpBoss);

        // Update the HP bar
        bossHP.fillAmount = hpBoss / maxHpBoss;

        if (hpBoss <= 0 && bossDeath == false )
        {
            // Handle boss death
            BossDefeated();
            ScoreManager2.instance.AddBonus(2000);
        }
    }

    public void IncreaseHP(float amount)
    {
        hpBoss += amount;
        hpBoss = Mathf.Clamp(hpBoss, 0, maxHpBoss);

        // Update the HP bar
        bossHP.fillAmount = hpBoss / maxHpBoss;
    }

    private IEnumerator RegenerateHP()
    {
        while (isRegenerating == true)
        {
            yield return new WaitForSeconds(regenInterval);

            if (hpBoss < maxHpBoss)
            {
                IncreaseHP(regenAmount);
            }
        }
    }

    private void BossDefeated()
    {
        bossdeath.Invoke();

        objectBoss.SetActive(false);

        bossDeath = true;
        
        Time.timeScale = 0.2f;
        isRegenerating = false;
        mainCamera.SetActive(false);
        cutSceneCamera.SetActive(true);

        foreach(GameObject i in UI){
            i.SetActive(false);

        }

        GameObject destroyVFXState = Instantiate(destroyVFX, deadspawn.position, Quaternion.identity);

        Destroy(destroyVFXState,5f);
        // Code to handle what happens when the boss is defeated
        Debug.Log("Boss defeated!");
        // Example: Destroy the boss game object
        StartCoroutine(Winner());

    }

    IEnumerator Winner(){
        yield return new WaitForSeconds(1f);
        Time.timeScale = 1f;
        UIWIN.SetActive(true);
        yield return new WaitForSeconds(5f);
        Time.timeScale = 0f;
        uiResult.SetActive(true);
    }
}
