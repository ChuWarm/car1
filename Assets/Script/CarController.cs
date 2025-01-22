using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float laneWidth = 1.5f;  
    private int currentLane = 1;   // 현재 위치 (0: 왼쪽, 1: 중앙, 2: 오른쪽)
    public float moveSpeed = 8f;  

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 touchPosition = Input.mousePosition;
            if (touchPosition.x < Screen.width / 2 && currentLane > 0)
            {
                currentLane--;
            }
            else if (touchPosition.x >= Screen.width / 2 && currentLane < 2)
            {
                currentLane++;
            }
        }
        
        Vector3 targetPosition = new Vector3(currentLane * laneWidth - laneWidth, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }
}
