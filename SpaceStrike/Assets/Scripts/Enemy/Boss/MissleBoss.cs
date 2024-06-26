using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileBoss : MonoBehaviour
{
    public float speed = 5f; // Kecepatan saat boss bergerak menuju player
    private Transform player;

    // Start dipanggil sebelum frame pertama update
    void Start()
    {
        // Cari objek player dengan tag
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        else
        {
            Debug.LogWarning("Objek dengan tag 'Player' tidak ditemukan.");
        }
    }

    // Update dipanggil sekali per frame
    void Update()
    {
        // Periksa apakah player sudah terdeteksi
        if (player != null)
        {
            // Simpan rotasi awal
            Vector3 originalRotation = transform.eulerAngles;

            // Arahkan ke player
            transform.LookAt(player);

            // Hanya ubah rotasi y, tetap pertahankan rotasi x dan z
            Vector3 newRotation = transform.eulerAngles;
            newRotation.x = originalRotation.x;
            newRotation.z = originalRotation.z;
            transform.eulerAngles = newRotation;

            // Gerakkan missile boss menuju player
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }
}
