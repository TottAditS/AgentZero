using UnityEngine;
public class PlayerTriggerStage : MonoBehaviour
{
    // Fungsi yang dipanggil saat player masuk trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Periksa apakah objek yang masuk trigger adalah player
        if (other.CompareTag("Player")) // Pastikan player memiliki tag "Player"
        {
            // Panggil fungsi Win di GameManager
            GameManager.Instance.StartLevel();
        }
    }
}
