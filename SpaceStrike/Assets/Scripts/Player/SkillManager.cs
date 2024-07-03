using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillManager : MonoBehaviour
{
    public Transform playerTransform;
    
    [Header("BasicAttack")]
    public GameObject basicAttackVFXPrefab;
    public Transform basicAttackVFXSpawnPoint;
    public KeyCode basicAttackKey;
    public GameObject cdVFX;
    public GameObject soundbasicattack;


    public Image basicAttackCooldownImage;

    public float basicAttackCooldownDuration = 1f;
    private bool isBasicAttackOnCooldown = false;
    private float basicAttackCooldownTimer = 0.0f;

    public float vfxSpeed; // Speed at which the VFX moves forward
    private bool isAttacking = false;

    [Header("Skill 1")]
    public Image skill1CooldownImage;
    public GameObject shieldVFXPrefab;

    public GameObject skill1vfxcd;

    public GameObject soundskill1;

    public KeyCode shieldKey;
    public float skill1CooldownDuration = 5.0f;
    private bool isSkill1OnCooldown = false;
    private float skill1CooldownTimer = 0.0f;

    [Header("Skill 2")]
    public Image skill2CooldownImage;
    public KeyCode skill2Key;
    public GameObject healthRegenerationVFX;

    public GameObject skill2vfxcd;

    public GameObject soundskill2;
    public float skill2CooldownDuration = 15f;
    private bool isSkill2Cooldown = false;
    private float skill2CooldownTimer = 0.0f;

    [Header("Skill 3")]
    public Image skill3CooldownImage;
    public Transform skill3SpawnPoint;
    public KeyCode skill3Key;
    public GameObject skill3VFX;
    private GameObject currentShieldVFX;

    public GameObject skill3vfxcd;

    public GameObject soundskill3;
    public float skill3CooldownDuration = 20f;
    private bool isSkill3Cooldown = false;
    private float skill3CooldownTimer = 0.0f;

    [Header("Skill 4")]
    public Image skill4CooldownImage;
    public Transform skill4SpawnPoint;
    public KeyCode skill4Key;
    public GameObject skill4VFX;

    public GameObject skill4vfxcd;

    public GameObject soundskill4;
    public float skill4CooldownDuration = 30f;
    private bool isSkill4Cooldown = false;
    private float skill4CooldownTimer = 0.0f;

    [Header("Skill 5")]
    public Image skill5CooldownImage;
    public Transform skill5SpawnPoint;
    public KeyCode skill5Key;
    public GameObject skill5VFX;

    public GameObject ultimatevfxcd;

    public GameObject soundskillultimate;
    public float skill5CooldownDuration = 30f;
    private bool isSkill5Cooldown = false;
    private float skill5CooldownTimer = 0.0f;

    public float ultimatespeed;


    private PlayerAttribut playerAttribut;





    // Start is called before the first frame update
    void Start()
    {

        skill1CooldownImage.fillAmount = 0;
        

    }

    void Awake()
    {
        playerAttribut = FindObjectOfType<PlayerAttribut>();

    }

    // Update is called once per frame
    void Update()
    {
        CooldownBasicAttack();
        // Check if the basic attack key is pressed and no attack is in progress
        if (Input.GetKey(basicAttackKey)  && !isBasicAttackOnCooldown )
        {
            BasicAttack();
        }

        // SKILL 1 ( SHIELD )
        CooldownShield();
        if (Input.GetKeyDown(shieldKey) && !isSkill1OnCooldown )
        {
    
            ActivateShield();
        }
        
        // SKILL 2 ( HP REGENERATION )
        CooldownHealthRegeneration();
        if (Input.GetKeyDown(skill2Key) && !isSkill2Cooldown )
        {

            HealthRegeneration();
        }

        //SKILL 3 ( METEOR HAMMER )

        CooldownMeteor();
        if (Input.GetKeyDown(skill3Key) && !isSkill3Cooldown )
        {

            MeteorSkill();
        }

        //SKILL 4 ( METEOR HAMMER )
        CooldownLightning();
        if(Input.GetKeyDown(skill4Key) && !isSkill4Cooldown )
        {
    
            LightningSkill();
        }

        CooldownUltimate();
        if(Input.GetKeyDown(skill5Key) && !isSkill5Cooldown )
        {
    
            Ultimate();
        }
    }

    #region Basic Attack
    public void BasicAttack()
    {
        // Instantiate the basic attack VFX at the spawn point
        GameObject basicAttackVFX = Instantiate(basicAttackVFXPrefab, basicAttackVFXSpawnPoint.position, Quaternion.identity);
        GameObject soundbasic = Instantiate(soundbasicattack, basicAttackVFXSpawnPoint.position, Quaternion.identity);

        Destroy(basicAttackVFX,3f);
        Destroy(soundbasic,3f);

        cdVFX.SetActive(false);

        isBasicAttackOnCooldown = true;
        basicAttackCooldownTimer = basicAttackCooldownDuration;
        basicAttackCooldownImage.fillAmount = 1;



        // Start moving the VFX forward
        StartCoroutine(MoveVFXForward(basicAttackVFX));



        // Add a component to handle collision and destruction
    }

    void CooldownBasicAttack(){
        if (isBasicAttackOnCooldown)
        {
            basicAttackCooldownTimer -= Time.deltaTime;
            basicAttackCooldownImage.fillAmount = basicAttackCooldownTimer / basicAttackCooldownDuration;

            if (basicAttackCooldownTimer <= 0)
            {
                isBasicAttackOnCooldown = false;
                basicAttackCooldownImage.fillAmount = 0;
                cdVFX.SetActive(true);
            }
        }
    }


    private IEnumerator MoveVFXForward(GameObject vfx)
    {
        while (vfx != null)
        {
            // Move the VFX forward along its local z-axis
            vfx.transform.Translate(Vector3.forward * vfxSpeed * Time.deltaTime);
            yield return null; // Wait for the next frame
        }
    }
    #endregion

    #region Shield

    void CooldownShield(){
        if (isSkill1OnCooldown)
        {
            skill1CooldownTimer -= Time.deltaTime;
            skill1CooldownImage.fillAmount = skill1CooldownTimer / skill1CooldownDuration;

            if (skill1CooldownTimer <= 0)
            {
                isSkill1OnCooldown = false;
                skill1CooldownImage.fillAmount = 0;
                
                skill1vfxcd.SetActive(true);
            }
        }
    }
    void ActivateShield()
    {
        // Destroy any existing shield VFX to prevent multiple instances
        if (currentShieldVFX != null)
        {
            Destroy(currentShieldVFX);
        }
        PlayerAttribut.instance.haveShield = true;

        skill1vfxcd.SetActive(false);

        // Instantiate the shield VFX at the player's position
        currentShieldVFX = Instantiate(shieldVFXPrefab, playerTransform.position, Quaternion.identity);
        
        GameObject sfxskill1 = Instantiate(soundskill1, playerTransform.position, Quaternion.identity);

        sfxskill1.transform.SetParent(playerTransform);
        
        Destroy(sfxskill1,10f);
        // The shield VFX should follow the player's position
        currentShieldVFX.transform.SetParent(playerTransform);

        Destroy(currentShieldVFX, 5f);

        StartCoroutine(TungguShieldHilang());

        // Start the cooldown
        isSkill1OnCooldown = true;
        skill1CooldownTimer = skill1CooldownDuration;
        skill1CooldownImage.fillAmount = 1;
    }

    IEnumerator TungguShieldHilang(){
        yield return new WaitForSeconds(5f);
        PlayerAttribut.instance.haveShield =false;
    }
    #endregion

    #region Health Regeneration

    void CooldownHealthRegeneration(){
        if (isSkill2Cooldown)
        {
            skill2CooldownTimer -= Time.deltaTime;
            skill2CooldownImage.fillAmount = skill2CooldownTimer / skill2CooldownDuration;

            if (skill2CooldownTimer <= 0)
            {
                isSkill2Cooldown = false;
                skill2CooldownImage.fillAmount = 0;
                skill2vfxcd.SetActive(true);
            }
        }
    }
    void HealthRegeneration()
    {
        skill2vfxcd.SetActive(false);
        StartCoroutine(regen());
        GameObject healthRegenerationPrefab = Instantiate(healthRegenerationVFX, playerTransform.position, Quaternion.identity);

        GameObject sfxheal = Instantiate(soundskill2, playerTransform.position, Quaternion.identity);
        sfxheal.transform.SetParent(playerTransform);
        Destroy(sfxheal,10f);

        healthRegenerationPrefab.transform.SetParent(playerTransform);
        Destroy(healthRegenerationPrefab, 4f);


        isSkill2Cooldown = true;
        skill2CooldownTimer = skill2CooldownDuration;
        skill2CooldownImage.fillAmount = 1;
    }

    IEnumerator regen(){
        yield return new WaitForSeconds(3f);
        playerAttribut.IncreaseHealth(50f);
    }
    #endregion

    #region Meteor

    void CooldownMeteor(){
        if (isSkill3Cooldown)
        {
            skill3CooldownTimer -= Time.deltaTime;
            skill3CooldownImage.fillAmount = skill3CooldownTimer / skill3CooldownDuration;

            if (skill3CooldownTimer <= 0)
            {
                isSkill3Cooldown = false;
                skill3CooldownImage.fillAmount = 0;
                skill3vfxcd.SetActive(true);
            }
        }
    }

    void MeteorSkill()
    {
        skill3vfxcd.SetActive(false);
        GameObject meteor = Instantiate(skill3VFX, skill3SpawnPoint.position, Quaternion.identity);

        GameObject sfxmeteor = Instantiate(soundskill3, skill3SpawnPoint.position, Quaternion.identity);
        
        Destroy(meteor, 4f);
        Destroy(sfxmeteor, 5f);

        isSkill3Cooldown = true;
        skill3CooldownTimer = skill3CooldownDuration;
        skill3CooldownImage.fillAmount = 1;
    }

    #endregion

    #region Lightning

    void CooldownLightning(){
        if (isSkill4Cooldown)
        {
            skill4CooldownTimer -= Time.deltaTime;
            skill4CooldownImage.fillAmount = skill4CooldownTimer / skill4CooldownDuration;

            if (skill4CooldownTimer <= 0)
            {
                isSkill4Cooldown = false;
                skill4CooldownImage.fillAmount = 0;
                skill4vfxcd.SetActive(true);
            }
        }
    }


    void LightningSkill()
    {
        skill4vfxcd.SetActive(false);
        GameObject lightning = Instantiate(skill4VFX, skill4SpawnPoint.position, Quaternion.identity);
        GameObject sfxlightning = Instantiate(soundskill4, skill4SpawnPoint.position, Quaternion.identity); 
        Destroy(lightning, 4f);
        Destroy(sfxlightning, 8f);

        isSkill4Cooldown = true;
        skill4CooldownTimer = skill4CooldownDuration;
        skill4CooldownImage.fillAmount = 1;
    }

    #endregion

    #region Ultimate
    void Ultimate(){

        ultimatevfxcd.SetActive(false);

        GameObject ultimate = Instantiate(skill5VFX, skill5SpawnPoint.position, Quaternion.identity);
        
        GameObject sfxultimate = Instantiate(soundskillultimate, skill5SpawnPoint.position, Quaternion.identity);
        StartCoroutine(MoveVFXUltimate(ultimate));


        Destroy(ultimate, 5f);
        Destroy(sfxultimate, 8f);

        isSkill5Cooldown = true;
        skill5CooldownTimer = skill5CooldownDuration;
        skill5CooldownImage.fillAmount = 1;

    }

    private IEnumerator MoveVFXUltimate(GameObject vfx)
    {
        float elapsedtime = 0f;
        while (vfx != null && elapsedtime <= 2f)
        {
            // Move the VFX forward along its local z-axis
            vfx.transform.Translate(Vector3.forward * ultimatespeed * Time.deltaTime);
            elapsedtime += Time.deltaTime;
            yield return null; // Wait for the next frame
        }
    }

    void CooldownUltimate(){
        if (isSkill5Cooldown)
        {
            skill5CooldownTimer -= Time.deltaTime;
            skill5CooldownImage.fillAmount = skill5CooldownTimer / skill5CooldownDuration;

            if (skill5CooldownTimer <= 0)
            {
                isSkill5Cooldown = false;
                skill5CooldownImage.fillAmount = 0;
                ultimatevfxcd.SetActive(true);
            }
        }
    }

    #endregion
}
