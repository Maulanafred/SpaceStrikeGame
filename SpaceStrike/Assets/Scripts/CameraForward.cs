using System.Collections;
using UnityEngine;

public class CameraForward : MonoBehaviour
{
    public int speed = 10;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ForwardCamera());
    }

    // Coroutine untuk menggerakkan kamera ke depan
    IEnumerator ForwardCamera()
    {
        while(true)
        {
            // Menggerakkan kamera sepanjang sumbu Z globalnya
            transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);
            yield return null; // Menunggu frame berikutnya
        }
    }
}
