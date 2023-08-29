using TMPro;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    private int collectibles = 0;

    [SerializeField] private TextMeshProUGUI collectiblesText;
    [SerializeField] private AudioSource collectionSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Collectable"))
        {
            collectionSound.Play();
            Destroy(collision.gameObject);
            collectibles++;
            collectiblesText.text = "Points: " + collectibles;
        }
    }
}
