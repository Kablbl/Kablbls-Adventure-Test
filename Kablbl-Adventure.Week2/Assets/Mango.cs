using UnityEngine;

public class Mango : MonoBehaviour
{
    public Vector3 rotationSpeed = new Vector3(0, 100, 0);  // Speed of rotation around each axis

    void Update()
    {
        RotateMango();  // Call the rotation function each frame
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))  // Check if the collider is the player
        {
            CollectMango();  // Handle the mango collection
        }
    }

    private void RotateMango()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime);  // Rotate the GameObject
    }

    private void CollectMango()
    {
        // Optionally, trigger any effects or update UI here
        gameObject.SetActive(false);  // Deactivate mango to make it "disappear"
    }
}