using UnityEngine;

public class TrashBehavior : MonoBehaviour
{
    // Tipe sampah ini, menggunakan enum dari GameManager
    public GameManager.TrashType trashType;

    public GameManager gameManager;  // Referensi GameManager

    void Start()
    {
        // Mendapatkan referensi GameManager jika belum ada
        gameManager = GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Cek apakah sampah menyentuh tong sampah
        TrashBin bin = collision.GetComponent<TrashBin>();
        if (bin != null)
        {
            // Panggil metode untuk mengatur logika di TrashBin
            bin.HandleTrashSorting(this);
        }
    }
}
