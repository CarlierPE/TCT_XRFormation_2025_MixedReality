using System;
using System.Collections.Generic;
using UnityEngine;

public class FireInstancate : MonoBehaviour
{
    [SerializeField] List<GameObject> _firePrefab; // Reference to the fire prefab
    [SerializeField] float _spawnInterval = 5f; // Time interval between spawns

    private float _nextSpawnTime; // Time when the next fire will be spawned
    private bool _isFireActive; // Flag to check if fire is active
    private int _fireCount; // Counter for the number of fires spawned
    private int _spawnCount = 0;
    private bool _isFireMax = false; // Flag to check if the maximum number of fires has been reached

    void Awake()
    {
        _fireCount = _firePrefab.Count;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_isFireActive)
        {
            if (_isFireMax) return; // If the maximum number of fires has been reached, do not spawn more fires
            NextFire(); // Call the SpawnFire method if fire is active
        }
    }

    public void StartFire()
    {
        if(!_isFireActive) // Check if fire is already active
        {
            if (_nextSpawnTime is 0 ) // Check if the next spawn time is not set
            {
                _nextSpawnTime = Time.time + _spawnInterval; // Initialize the next spawn time to the current time
                _isFireActive = true;
            }

        }

        _isFireActive = true; // Set the fire active flag to true

    }

    private void NextFire()
    {
        if (Time.time < _nextSpawnTime) return; // Check if it's time to spawn the next fire  

        if (_spawnCount >= _fireCount) // Check if all fire prefabs have been spawned
        {
            FireMax(); // Stop spawning fires if all have been spawned
            return;
        }

        _firePrefab[_spawnCount].SetActive(true); // Activate the fire prefab at the current spawn count
        _spawnCount++; // Increment the spawn count
        _nextSpawnTime = _nextSpawnTime + _spawnInterval; // Update the next spawn time  

        
    }

    private void FireMax()
    {
        _isFireMax = true; // Set the fire active flag to false
    }

    public void ResetFire()
    {
        if (_isFireActive)
        {
            AllFirePrefab(); // Deactivate all fire prefabs
            _nextSpawnTime = 0; // Reset the next spawn time
            _isFireActive = false; // Set the fire active flag to false
            _isFireMax = false; // Reset the maximum fire flag
            _spawnCount = 0; // Reset the spawn count
        }
    }

    private void AllFirePrefab()
    {
        foreach (GameObject fire in _firePrefab)
        {
            fire.SetActive(false); // Deactivate all fire prefabs
        }
    }

    public void PauseFire()
    {         
        _isFireActive = false; // Set the fire active flag to false to pause fire spawning
    }

    public void InstantieFire(List<GameObject> fires)
    {
        _firePrefab.Clear();

        _firePrefab = fires;

        _fireCount = _firePrefab.Count;
    }

    public void SetInterval(int interval)
    {
        _spawnInterval = interval;
    }
}
