using UnityEngine;

public class SceneFlow : MonoBehaviour
{
    public void Restart() => GameManager.Instance.RestartLevel();
    public void NextLevel() => GameManager.Instance.NextLevel();
}
