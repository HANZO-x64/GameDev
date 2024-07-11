using System.Collections.Generic;
using UnityEngine;

public class SpawnChunks : MonoBehaviour
{
    [Header("General parameters")]
    [SerializeField] private Transform playerTransform;
    [SerializeField] private string playerTag;
    public Chunk FirstChunk;
    [SerializeField] private Transform firstChunkPos;
    public static bool spawnFirstChunk = false;
    public Chunk[] ChunkPrefabs;
    private List<Chunk> spawnedChunks = new List<Chunk>();

    private void Awake()
    {
        CheckPlayerOnScene();
    }
    private void Start()
    {
        spawnedChunks.Add(FirstChunk);
    }

    private void Update()
    {
        if (spawnFirstChunk == true)
        {
            Instantiate(FirstChunk, firstChunkPos);
            spawnFirstChunk = false;
        }
        if (playerTransform.position.x > spawnedChunks[spawnedChunks.Count - 1].End.position.x - 100f)
        {
            SpawnChunk();
        }
        if (this.playerTransform == null) CheckPlayerOnScene();
    }

    private void SpawnChunk()
    {
        Chunk newChunk = Instantiate(ChunkPrefabs[Random.Range(0, ChunkPrefabs.Length)]);
        newChunk.transform.position = spawnedChunks[spawnedChunks.Count - 1].End.position - newChunk.Begin.localPosition;
        spawnedChunks.Add(newChunk);

        if (spawnedChunks.Count >= 3)
        {
            Destroy(spawnedChunks[0].gameObject);
            spawnedChunks.RemoveAt(0);
        }
    }
    private void CheckPlayerOnScene()
    {
        if (this.playerTransform == null)
        {
            if (this.playerTag == "")
            {
                this.playerTag = "Player";
            }

            this.playerTransform = GameObject.FindGameObjectWithTag(this.playerTag).transform;
        }
    }
}
