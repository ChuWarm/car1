using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject tilePrefab;
    public float scrollSpeed = 5f;  // 맵 스크롤 속도
    public float tileLength = 5f; // 타일 길이

    void Awake()
    {
        GameObject[] cameras = GameObject.FindGameObjectsWithTag("MainCamera");
        if (cameras.Length > 1)
        {
            Destroy(cameras[1]); // 중복된 카메라 제거
        }
    }

    void Update()
    {
        tilePrefab.transform.Translate( new Vector3(0, -1, 0) * scrollSpeed * Time.deltaTime);

        if (tilePrefab.transform.position.y < -tileLength)
        {
            tilePrefab.transform.position = new Vector3(-6.5f, tileLength, 0);
        }
    }
}