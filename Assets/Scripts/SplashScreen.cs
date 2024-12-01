using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class SplashScreen : MonoBehaviour
{
    [SerializeField] private Image loadingBar; // �ε� �� �̹���
    [SerializeField] private RectTransform circle; // �̵��� Circle �̹��� (RectTransform)
    private float splashDuration = 20f; // ���÷��� ȭ�� ���� �ð�

    void Start()
    {
        // ���α׷����� ä���
        if (loadingBar != null)
        {
            loadingBar.fillAmount = 0f; // �ʱ� ����
            loadingBar.DOFillAmount(1f, splashDuration).SetEase(Ease.Linear); // 1���� ä���
        }

        // Circle �̹��� �̵�
        if (circle != null)
        {
            MoveCircle();
        }

        // Splash ���� �� �� �̵�
        DOVirtual.DelayedCall(splashDuration, EndSplashScreen);
    }

    void MoveCircle()
    {
        // ���� ��ġ: right 90%
        Vector2 startAnchor = new Vector2(0.9f, circle.anchorMin.y); // anchorMin ����
        circle.anchorMin = startAnchor;
        circle.anchorMax = startAnchor;

        // ��ǥ ��ġ: left 90%
        Vector2 targetAnchor = new Vector2(0.1f, circle.anchorMin.y); // left 90%

        // DOTween���� anchorMin�� anchorMax �̵�
        circle.DOAnchorMin(targetAnchor, splashDuration).SetEase(Ease.OutQuad);
        circle.DOAnchorMax(targetAnchor, splashDuration).SetEase(Ease.OutQuad);
    }

    void EndSplashScreen()
    {
        SceneManager.LoadScene("MainScene"); // ���� ������ �̵�
    }
}
