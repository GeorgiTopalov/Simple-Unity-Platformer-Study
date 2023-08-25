using TMPro;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    private int collectibles = 0;

    [SerializeField] private TextMeshProUGUI collectiblesText;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Collectable"))
        {
            Destroy(collision.gameObject);
            collectibles++;
            collectiblesText.text = "Points: " + collectibles;
        }
    }
}
