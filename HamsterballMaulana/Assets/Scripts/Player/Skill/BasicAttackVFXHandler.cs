using UnityEngine;


public class BasicAttackVFXHandler : MonoBehaviour
{

    private SkillManager skillManager;

    private float lifeTime;

    public void Awake()
    {
    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy")) // Assuming enemies have the tag "Enemy"
        {
            // Destroy the VFX immediately upon collision with an enemy
            Destroy(gameObject);
        }
    }

}
