using UnityEngine;

public class cameraController : MonoBehaviour
{
    [SerializeField] private Transform character;
    private void Update()
    {
        transform.position = new Vector3(character.position.x, character.position.y, transform.position.z);
    }
}
