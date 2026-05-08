using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Game Settings")]
    public float levelTime = 60f;
    public int totalDiamonds = 7;

    private float currentTime;
    private int diamondsCollected;

    public bool isGameActive = true;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    void Start()
    {
        currentTime = levelTime;
        diamondsCollected = 0;
        UpdateUI();
    }

    void Update()
    {
        if (!isGameActive) return;

        currentTime -= Time.deltaTime;
        UpdateUI();

        if (currentTime <= 0f)
        {
            LoseGame();
        }
    }

    public void CollectDiamond()
    {
        diamondsCollected++;
        UpdateUI();

        if (diamondsCollected >= totalDiamonds)
        {
            WinGame();
        }
    }

    void WinGame()
    {
        isGameActive = false;
        UIManager.Instance.ShowWin();
        Debug.Log("You Win!");
    }

    void LoseGame()
    {
        isGameActive = false;
        UIManager.Instance.ShowLose();
        Debug.Log("Game Over");
    }

    void UpdateUI()
    {
        UIManager.Instance.UpdateTimer(Mathf.Max(0, currentTime));
        UIManager.Instance.UpdateDiamonds(diamondsCollected, totalDiamonds);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        isGameActive = true;
    }

    public void NextLevel()
    {
        int nextIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextIndex < SceneManager.sceneCountInBuildSettings)
            SceneManager.LoadScene(nextIndex);
        else
            Debug.Log("Game Completed!");
    }
}