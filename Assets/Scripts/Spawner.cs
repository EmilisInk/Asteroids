using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static int spawnCount;

    public List<GameObject> prefabs;
    public int amount = 10;

    public Vector2 mapStart = new Vector3(-10, -3,6);
    public Vector2 mapEnd = new Vector3(10, 3,6);

    public Transform player;
    public float minDistanceFromPlayer = 3f;

    private void Start()
    {
        spawnCount = 0;
    }

    private void Update()
    {
        if (player == null)
        {
            return;
        }


        if (spawnCount < amount)
        {
            spawnCount++;

            float x = Random.Range(mapStart.x, mapEnd.x);
            float y = Random.Range(mapStart.y, mapEnd.y);
            Vector3 position = new Vector3(x, y, 0f);

            if (Vector3.Distance(position, player.position) < minDistanceFromPlayer) return;

            var rotation = Quaternion.Euler(0, 0, Random.Range(0f, 360f));

            var p = prefabs[Random.Range(0, prefabs.Count)];

            Instantiate(p, position, rotation);
        }
    }
}
