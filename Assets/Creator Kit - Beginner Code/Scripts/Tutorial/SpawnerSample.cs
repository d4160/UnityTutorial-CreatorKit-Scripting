using UnityEngine;
using CreatorKitCode;

public class SpawnerSample : MonoBehaviour
{
    public GameObject ObjectToSpawn;
    public int radius = 5;
    public int angleStep = 45;

    void Start()
    {
        LootAngle spawnAngle = new LootAngle(angleStep);

        //every call will advance the angle!
        SpawnPotion(spawnAngle.NextAngle());
        SpawnPotion(spawnAngle.NextAngle());
        SpawnPotion(spawnAngle.NextAngle());
        SpawnPotion(spawnAngle.NextAngle());
    }

    void SpawnPotion(int angle)
    {
        Vector3 direction = Quaternion.Euler(0, angle, 0) * Vector3.right;
        Vector3 spawnPosition = transform.position + direction * radius;
        Instantiate(ObjectToSpawn, spawnPosition, Quaternion.identity);
    }
}

public class LootAngle
{
    int angle;
    int step;

    public LootAngle(int increment)
    {
        step = increment;
        angle = 0;
    }

    public int NextAngle()
    {
        int currentAngle = angle;
        angle = Helpers.WrapAngle(angle + step);

        return currentAngle;
    }
}

