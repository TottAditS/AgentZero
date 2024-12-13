using UnityEngine;
public class TrashBin : MonoBehaviour
{
    // Enum untuk tipe sampah yang diterima tong sampah
    public TrashBehavior.TrashType acceptedTrashType;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Deteksi apakah ada objek sampah yang masuk
        TrashBehavior trash = collision.GetComponent<TrashBehavior>();
        if (trash != null)
        {
            // Logika pemeriksaan tipe sampah ditangani di TrashBehavior
            Debug.Log($"Trash entered bin: {trash.trashType}");
        }
    }
}
 