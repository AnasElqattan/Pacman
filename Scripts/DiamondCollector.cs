using UnityEngine;

public class DiamondCollector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectible"))
        {
            Destroy(other.gameObject);
            GameManager.Instance.CollectDiamond();
        }
    }
}
