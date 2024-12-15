using UnityEngine;
using UnityEngine.EventSystems;  // Untuk menangani event PointerDown dan PointerUp

public class ButtonMovement : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Movement movementScript;  // Referensi ke script Movement

    // Fungsi untuk ketika tombol ditekan
    public void OnPointerDown(PointerEventData eventData)
    {
        if (gameObject.name == "ButtonLeft")
        {
            movementScript.MoveLeft();
        }
        else if (gameObject.name == "ButtonRight")
        {
            movementScript.MoveRight();
        }
    }

    // Fungsi untuk ketika tombol dilepas
    public void OnPointerUp(PointerEventData eventData)
    {
        movementScript.StopMove();  // Berhenti bergerak saat tombol dilepas
    }
}
