using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        // Hancurkan jika sudah jauh ke kiri (di luar layar)
        if (transform.position.x < Camera.main.transform.position.x - 15f)
        {
            Destroy(gameObject);
        }
    }
}