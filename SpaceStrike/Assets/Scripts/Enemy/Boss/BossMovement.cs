using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public Transform player;

    public float posisi;
    public float smoothTime = 0.3f; // Waktu redaman halus
    private Vector3 velocity = Vector3.zero; // Kecepatan awal redaman halus

    // Start is called before the first frame update
    void Start()
    {
        // Tidak ada inisialisasi yang diperlukan di sini untuk saat ini
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            // Simpan posisi saat ini
            Vector3 targetPosition = new Vector3(player.position.x + posisi, transform.position.y, transform.position.z);

            // Terapkan smooth damp untuk menggerakkan bos menuju posisi player
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }
}
