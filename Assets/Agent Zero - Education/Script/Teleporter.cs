using UnityEngine;
using DG.Tweening;
using UnityEngine.UI; // Untuk UI Image fade effect
using System.Collections;

public class Teleporter : MonoBehaviour
{
    [Header("Teleport Settings")]
    public Transform targetLocation; // Lokasi tujuan teleport
    public float delayBeforeTeleport = 1f; // Waktu tunggu sebelum teleport

    [Header("Fade Settings")]
    public Image fadeScreen; // UI Image untuk transisi fade
    public float fadeDuration = 0.5f; // Durasi fade in/out

    [Header("Player Detection")]
    public string playerTag = "Player"; // Tag pemain yang dikenali

    private bool isTeleporting = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(playerTag) && !isTeleporting)
        {
            StartCoroutine(TeleportPlayer(collision.gameObject));
        }
    }

    private IEnumerator TeleportPlayer(GameObject player)
    {
        isTeleporting = true;

        // Fade to black
        if (fadeScreen != null)
        {
            fadeScreen.gameObject.SetActive(true);
            fadeScreen.DOFade(1f, fadeDuration); // Fade in
        }

        // Tunggu sampai fade selesai dan delay
        yield return new WaitForSeconds(delayBeforeTeleport);

        // Teleport pemain ke lokasi target
        player.transform.position = targetLocation.position;

        // Fade back to clear
        if (fadeScreen != null)
        {
            fadeScreen.DOFade(0f, fadeDuration).OnComplete(() =>
            {
                fadeScreen.gameObject.SetActive(false);
                isTeleporting = false;
            });
        }
    }
}
