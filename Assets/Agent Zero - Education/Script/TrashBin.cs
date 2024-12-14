using UnityEngine;

public class TrashBin : MonoBehaviour
{
    // Enum untuk tipe sampah yang diterima tong sampah, menggunakan enum dari GameManager
    public GameManager.TrashType acceptedTrashType;

    private GameManager gameManager;  // Referensi GameManager

    void Start()
    {
        // Mendapatkan referensi GameManager
        gameManager = FindObjectOfType<GameManager>();
    }

    // Menangani logika pemilihan sampah di sini
    public void HandleTrashSorting(TrashBehavior trash)
    {
        // Cek apakah tipe sampah sesuai dengan yang diterima tong sampah
        if (trash.trashType == acceptedTrashType)
        {
            // Sampah benar, beri tahu GameManager
            gameManager.RegisterTrashSorting(true);
        }
        else
        {
            // Sampah salah, beri tahu GameManager
            gameManager.RegisterTrashSorting(false);
        }

        // Hapus sampah setelah di-sort
        Destroy(trash.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Deteksi apakah ada objek sampah yang masuk
        TrashBehavior trash = collision.GetComponent<TrashBehavior>();
        if (trash != null)
        {
            // Logika pemeriksaan tipe sampah ditangani di TrashBin
            Debug.Log($"Trash entered bin: {trash.trashType}");
        }
    }
}
