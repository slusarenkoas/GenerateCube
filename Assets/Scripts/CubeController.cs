using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class CubeController : MonoBehaviour
{
    [SerializeField] private Transform [] _cubePrefabs;
    [SerializeField] private Transform _leftPosition;
    [SerializeField] private Transform _rightPosition;
    
    
    
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            GeneratorPrefabs();
        }
    }

    private void GeneratorPrefabs()
    {
        var randomIndexPrefab = Random.Range(0, _cubePrefabs.Length);
        
        var newPrefab = Instantiate(_cubePrefabs[randomIndexPrefab]);
        
        var position = _leftPosition.position;
        var generatePointGeneration = new Vector3(Random.Range(position.x, _rightPosition.position.x),
            position.y, position.z);

       newPrefab.position = generatePointGeneration;
    }
}
