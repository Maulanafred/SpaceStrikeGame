using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasicAttack : MonoBehaviour
{
    public Transform spawnBasicAttack;
    public GameObject vfxBasicAttackEnemy;
    public float vfxSpeed;

    // Start is called before the first frame update
    void Start()
    {
        spawnBasicAttack = GetComponent<Transform>();
        StartCoroutine(BasicAttackRoutine());
    }

    // Coroutine to handle the basic attack timing
    IEnumerator BasicAttackRoutine()
    {
        while (true)
        {
            // Randomize the wait time between 1 and 2 seconds
            float waitTime = Random.Range(1f, 2f);
            yield return new WaitForSeconds(waitTime);

            // Instantiate the VFX at the spawn point
            GameObject basic = Instantiate(vfxBasicAttackEnemy, spawnBasicAttack.position, Quaternion.Euler(90, 0, 0));

            // Detach the VFX from the parent so it continues moving even if the parent is destroyed


            Destroy(basic, 4f);
        }
    }

    private IEnumerator MoveVFXForward(GameObject vfx)
    {
        while (vfx != null)
        {
            // Move the VFX forward along its local z-axis
            vfx.transform.Translate(Vector3.down * vfxSpeed * Time.deltaTime);
            yield return null; // Wait for the next frame
        }

    }
}
