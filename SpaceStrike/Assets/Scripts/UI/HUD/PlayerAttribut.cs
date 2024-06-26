using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttribut : MonoBehaviour
{
    public static PlayerAttribut instance;

    private BoxCollider col;

    public bool haveShield;
    public Image healthPlayerImage;
    public Image manaPlayerImage;

    public float healthPlayer = 100f;
    public float maxHealth = 100f;
    
    private float regenerationInterval = 1f; // Interval for regeneration in seconds

    // Start is called before the first frame update
    void Start()
    {
        // Ensure there is only one instance of PlayerAttribute
        if (instance == null)
        {
            instance = this;
        }

        col = GetComponent<BoxCollider>();


        // Start coroutine for regeneration
        StartCoroutine(RegenerateHealth());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ReduceHealth(20);
        }

        if(healthPlayer <= 0f){
            UiManagementGame.instance.GameOver();
        }
    }

    public void OnTriggerEnter(Collider other){
        if(other.CompareTag("BasicAttackEnemy") && haveShield == false){
            ReduceHealth(2);
            Destroy(other.gameObject);
        }
        if(other.CompareTag("BasicAttackBoss") && haveShield == false){
            ReduceHealth(10);
            Destroy(other.gameObject);
        }
    }

    // Coroutine for regenerating health
    IEnumerator RegenerateHealth()
    {
        while (true)
        {
            yield return new WaitForSeconds(regenerationInterval);

            // Regenerate health
            if (healthPlayer < maxHealth)
            {
                healthPlayer += 0.2f;
                healthPlayer = Mathf.Min(healthPlayer, maxHealth); // Ensure health doesn't exceed max health
                healthPlayerImage.fillAmount = healthPlayer / maxHealth;
            }
        }
    }

    // Method to reduce health
    public void ReduceHealth(float amount)
    {
        healthPlayer -= amount;
        healthPlayer = Mathf.Max(healthPlayer, 0); // Ensure health doesn't go below 0
        healthPlayerImage.fillAmount = healthPlayer / maxHealth;
    }

    public void IncreaseHealth(float amount)
    {
        healthPlayer += amount;
        healthPlayer = Mathf.Min(healthPlayer,maxHealth); // Ensure health doesn't go below 0
        healthPlayerImage.fillAmount = healthPlayer / maxHealth;
    }
}
