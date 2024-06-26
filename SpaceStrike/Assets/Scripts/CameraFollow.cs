using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Transform pemain
    public Vector3 offset; // Jarak relatif antara kamera dan pemain
    public float rotationDamping = 3f; // Damping rotasi kamera

    private void LateUpdate()
    {
        // Hitung rotasi yang diinginkan
        Quaternion wantedRotation = Quaternion.Euler(27.01f, player.eulerAngles.y, 0);

        // Damp the rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, wantedRotation, rotationDamping * Time.deltaTime);

        // Set the position of the camera relative to the player
        transform.position = player.position - transform.forward * offset.z +
                              transform.up * offset.y +
                              transform.right * offset.x;
    }

    // private void OnValidate()
    // {
    //     // Update the camera's position in the editor
    //     transform.position = player.position - transform.forward * offset.z +
    //                           transform.up * offset.y +
    //                           transform.right * offset.x;
    //}
}
