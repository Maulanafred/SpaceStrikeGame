using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerForward : MonoBehaviour
{
    public float speed = 10;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(ForwardPlayer());
    }

    // Coroutine untuk menggerakkan player ke depan
    IEnumerator ForwardPlayer()
    {
        while(true)
        {
            // Menggerakkan player sepanjang sumbu Z globalnya
            rb.velocity = transform.forward * speed;
            yield return null; // Menunggu frame berikutnya
        }
    }

    private void OnDestroy()
    {
        // Menghentikan pergerakan saat objek dihancurkan
        rb.velocity = Vector3.zero;
    }
}
