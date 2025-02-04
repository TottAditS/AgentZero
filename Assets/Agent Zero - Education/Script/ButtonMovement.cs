using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonMovement : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Movement movementScript; // Hubungkan ke script Movement

    // Fungsi untuk ketika tombol ditekan
    public void OnPointerDown(PointerEventData eventData)
    {
        if (gameObject.name == "ButtonLeft")
        {
            movementScript.MoveLeft(); // Panggil gerakan ke kiri
            //Debug.Log("putarkekiriiee");
        }
        else if (gameObject.name == "ButtonRight")
        {
            movementScript.MoveRight(); // Panggil gerakan ke kanan
            //Debug.Log("putarkekananeee");
        }
    }

    // Fungsi untuk ketika tombol dilepas
    public void OnPointerUp(PointerEventData eventData)
    {
        movementScript.StopMove(); // Hentikan gerakan saat tombol dilepas
        //Debug.Log("sotpsotpsototpo");
    }
}
