using UnityEngine;

public class TrashBehavior : MonoBehaviour
{
    // Enum untuk tipe sampah
    public enum TrashType
    {
        Organic,
        Recyclable,
        Hazardous
    }

    // Tipe sampah ini
    public TrashType trashType;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Cek apakah sampah menyentuh tong sampah
        TrashBin bin = collision.GetComponent<TrashBin>();
        if (bin != null)
        {
            // Cek apakah tipe sampah sesuai dengan tong sampah
            if (bin.acceptedTrashType == trashType)
            {
                Debug.Log("Correct bin! Trash disposed successfully.");
                Destroy(gameObject); // Hapus sampah
            }
            else
            {
                Debug.Log("Wrong bin! Try again.");
            }
        }
    }
}
