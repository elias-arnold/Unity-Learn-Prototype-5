using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private GameManager _gameManager;
    public int scoreValue;

    public ParticleSystem explosion;
    // Start is called before the first frame update
    void Start()
    {
        targetRb = gameObject.GetComponent<Rigidbody>();
        targetRb.AddForce(Vector3.up * Random.Range(12,18), ForceMode.Impulse);
        targetRb.AddTorque(Random.Range(0,10),Random.Range(0,10),Random.Range(0,10), ForceMode.Impulse);
        transform.position = new Vector3(Random.Range(-4f, 4f), -6);
        _gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
        _gameManager.updateScore(scoreValue);
        Instantiate(explosion, transform.position, Quaternion.identity);
        if (gameObject.CompareTag("Enemy"))
        {
            _gameManager.GameOver();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}