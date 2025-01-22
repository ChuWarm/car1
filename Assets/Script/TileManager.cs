using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject tilePrefab; // 타일 프리팹
    public int numTiles = 5;      // 화면에 표시될 타일 수
    public float tileLength = 10f; // 타일의 길이

    private List<GameObject> activeTiles = new List<GameObject>(); // 활성화된 타일 리스트
    private float spawnZ = 0f;    // 타일이 생성될 Z 위치
    private float safeZone = 15f; // 타일이 사라질 기준 거리
    private Transform playerTransform; // 플레이어(또는 카메라) 위치

    void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;

        // 초기 타일 생성
        for (int i = 0; i < numTiles; i++)
        {
            SpawnTile();
        }
    }

    void Update()
    {
        // 플레이어 위치를 기준으로 타일 관리
        if (playerTransform.position.z - safeZone > (spawnZ - numTiles * tileLength))
        {
            RecycleTile();
        }
    }

    void SpawnTile()
    {
        GameObject tile = Instantiate(tilePrefab, Vector3.forward * spawnZ, Quaternion.identity);
        activeTiles.Add(tile);
        spawnZ += tileLength; // 다음 타일의 Z 위치 계산
    }

    void RecycleTile()
    {
        // 첫 번째 타일 제거
        GameObject tileToRecycle = activeTiles[0];
        activeTiles.RemoveAt(0);

        // 타일을 맵 끝으로 이동
        tileToRecycle.transform.position = Vector3.forward * spawnZ;
        activeTiles.Add(tileToRecycle);

        spawnZ += tileLength; // 다음 타일의 Z 위치 계산
    }
}
public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        // Z축 방향으로 지속적인 이동
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
