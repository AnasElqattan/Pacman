using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("UI Elements")]
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI diamondText;
    public GameObject winPanel;
    public GameObject losePanel;

    void Awake()
    {
        Instance = this;
        winPanel.SetActive(false);
        losePanel.SetActive(false);
    }

    public void UpdateTimer(float time)
    {
        timerText.text = $"Time: {time:F0}";
    }

    public void UpdateDiamonds(int collected, int total)
    {
        diamondText.text = $"Diamonds: {collected} / {total}";
    }

    public void ShowWin()
    {
        winPanel.SetActive(true);
    }

    public void ShowLose()
    {
        losePanel.SetActive(true);
    }
}
