using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed = 10f; // Kecepatan bola

    private Rigidbody rb;
    private Vector3 lastMousePosition;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        lastMousePosition = Input.mousePosition; // Inisialisasi posisi mouse awal

    }


    private void Update()
    {
        ControlWithKeyboard();
        ControlWithMouse();
    }

    private void ControlWithKeyboard()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
    }

    private void ControlWithMouse()
    {
        Vector3 currentMousePosition = Input.mousePosition;
        Vector3 deltaMousePosition = currentMousePosition - lastMousePosition;

        if (deltaMousePosition.magnitude != 0)
        {
            // Mengubah delta mouse menjadi arah pergerakan bola dalam ruang dunia
            Vector3 moveDirection = new Vector3(deltaMousePosition.x, 0, deltaMousePosition.y).normalized;

            // Menggerakkan bola berdasarkan arah pergerakan mouse
            rb.AddForce(moveDirection * speed);
        }

        // Menyimpan posisi mouse saat ini untuk digunakan pada frame berikutnya
        lastMousePosition = currentMousePosition;
    }
}
