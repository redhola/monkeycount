using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Oyuncunun transformu. Unity Inspector'dan atanmalı.
    public Vector3 offset; // Kamera ile oyuncu arasındaki mesafe.

    void LateUpdate()
    {
        transform.position = player.position + offset;
    }
}
