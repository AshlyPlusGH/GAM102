using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectToSpawn; // The prefab to spawn
    public int numberOfObjects = 10; // Number of objects to spawn
    public Vector2 minPosition; // Minimum coordinates
    public Vector2 maxPosition; // Maximum coordinates
    public Vector2 minScale = new Vector2(1, 1); // Minimum scale
    public Vector2 maxScale = new Vector2(3, 3); // Maximum scale

    void Start()
    {
        SpawnObjects();
    }

    void SpawnObjects()
    {
        int spawnedCount = 0;

        while (spawnedCount < numberOfObjects)
        {
            // Generate random position within the given coordinates
            float randomX = Random.Range(minPosition.x, maxPosition.x);
            float randomY = Random.Range(minPosition.y, maxPosition.y);
            Vector2 randomPosition = new Vector2(randomX, randomY);

            // Generate random scale within the given limits
            float randomScaleX = Random.Range(minScale.x, maxScale.x);
            float randomScaleY = Random.Range(minScale.y, maxScale.y);
            Vector2 randomScale = new Vector2(randomScaleX, randomScaleY);

            // Check for collision with "Ship" objects
            if (!IsCollidingWithShip(randomPosition, randomScale))
            {
                // Instantiate the object if no collision detected
                GameObject newObject = Instantiate(objectToSpawn, randomPosition, Quaternion.identity);
                newObject.transform.localScale = randomScale;
                spawnedCount++;
            }
        }
    }

    bool IsCollidingWithShip(Vector2 position, Vector2 scale)
    {
        GameObject[] ships = GameObject.FindGameObjectsWithTag("Ship");
        foreach (GameObject ship in ships)
        {
            Collider2D shipCollider = ship.GetComponent<Collider2D>();
            if (shipCollider != null)
            {
                Bounds shipBounds = shipCollider.bounds;
                Bounds newObjectBounds = new Bounds(position, scale);
                if (shipBounds.Intersects(newObjectBounds))
                {
                    return true;
                }
            }
        }
        return false;
    }
}
