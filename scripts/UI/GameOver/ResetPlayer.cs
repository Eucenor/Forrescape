using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayer : MonoBehaviour
{
    [SerializeField]
    private Transform checkPoint;
    [SerializeField]
    private int spawnHeartCount = 3;
    [SerializeField]
    private Health health;
    [SerializeField]
    private Transform playerTransform;
    [SerializeField]
    private GameObject canvasGameOver;
    private void Start()
    {
        if(!health)
            health = GetComponent<Health>();
        Health.OnPlayerDead += ResetToCheckpoint;
    }
    public void ResetToCheckpoint()
    {
        playerTransform.position = checkPoint.position;
        health.SetDefaultHealth();
        canvasGameOver.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ResetToCheckpoint();
    }
    public void TeleportPlayerBack()
    {
        playerTransform.position = checkPoint.position;
    }
    private void OnDestroy()
    {
        Health.OnPlayerDead -= ResetToCheckpoint;
    }
}
