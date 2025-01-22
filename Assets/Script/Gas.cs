using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gas : MonoBehaviour
{
    public int gasAmount = 30; // 증가 가스량

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CarStats.Instance.IncreaseGas(gasAmount); // 자동차 가스 증가
            Destroy(gameObject); // 가스 아이템 제거
            Debug.Log("gas");
        }
    }
}
