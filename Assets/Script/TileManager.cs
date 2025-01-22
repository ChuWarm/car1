using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject tilePrefab;
    public float scrollSpeed = 5f;  // 맵 스크롤 속도
    public float tileLength = 10f; // 타일 길이

    void Start()
    {
    }

    void Update()
    {
        tilePrefab.transform.Translate( new Vector3(0, -1, 0) * scrollSpeed * Time.deltaTime);
    }
}