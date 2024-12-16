using UnityEngine;
using DG.Tweening;
using TMPro;
public class TriggerUI : MonoBehaviour
{
    [Header("UI Text Settings")]
    public GameObject InfoPanel;
    public float fadeDuration = 0.5f;
    public float displayDuration = 2f;

    private CanvasGroup canvasGroup;
    private bool isPlayerInside = false;

    private void Start()
    {
        // Pastikan textUI memiliki CanvasGroup
        canvasGroup = InfoPanel.GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = InfoPanel.AddComponent<CanvasGroup>();
        }

        // Sembunyikan teks saat awal
        canvasGroup.alpha = 0f;
        InfoPanel.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isPlayerInside)
        {
            isPlayerInside = true;
            ShowPanel(); // Contoh teks
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && isPlayerInside)
        {
            isPlayerInside = false;
            HidePanel();
        }
    }
    private void ShowPanel()
    {
        InfoPanel.SetActive(true);

        canvasGroup.DOFade(1f, fadeDuration);
    }
    private void HidePanel()
    {
        canvasGroup.DOFade(0f, fadeDuration).OnComplete(() =>
        {
            InfoPanel.SetActive(false);
        });
    }
}
