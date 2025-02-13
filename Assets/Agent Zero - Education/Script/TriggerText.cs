using UnityEngine;
using DG.Tweening;
using TMPro;
public class TriggerText : MonoBehaviour
{
    [Header("UI Text Settings")]
    public GameObject textUI;
    public float fadeDuration = 0.5f;
    public float displayDuration = 2f;

    private CanvasGroup canvasGroup;
    private bool isPlayerInside = false;

    private void Start()
    {
        // Pastikan textUI memiliki CanvasGroup
        canvasGroup = textUI.GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = textUI.AddComponent<CanvasGroup>();
        }

        // Sembunyikan teks saat awal
        canvasGroup.alpha = 0f;
        textUI.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isPlayerInside)
        {
            isPlayerInside = true;
            ShowText(); // Contoh teks
        }
    }

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Player") && isPlayerInside)
    //    {
    //        isPlayerInside = false;
    //        HideText();
    //    }
    //}

    private void ShowText(string message)
    {
        textUI.SetActive(true);

        // Jika menggunakan TextMeshPro, ubah teks
        TMP_Text tmpText = textUI.GetComponent<TMP_Text>();
        if (tmpText != null)
        {
            tmpText.text = message;
        }

        // Fade in dengan DoTween
        canvasGroup.DOFade(1f, fadeDuration).OnComplete(() =>
        {
            // Tahan teks selama displayDuration lalu hilangkan
            Invoke(nameof(HideText), displayDuration);
        });
    }

    private void ShowText()
    {
        textUI.SetActive(true);

        // Fade in dengan DoTween
        canvasGroup.DOFade(1f, fadeDuration).OnComplete(() =>
        {
            // Tahan teks selama displayDuration lalu hilangkan
            Invoke(nameof(HideText), displayDuration);
        });
    }

    private void HideText()
    {
        // Fade out dengan DoTween
        canvasGroup.DOFade(0f, fadeDuration).OnComplete(() =>
        {
            textUI.SetActive(false);
        });
    }
}
