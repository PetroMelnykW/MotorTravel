using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.U2D;

public class LevelGenerator : MonoBehaviour
{
    [Header("Ground")]
    [Range(1, 100)] 
    [SerializeField] private int _levelLength = 50;
    [Range(1f, 50f)] 
    [SerializeField] private float _xMultiplier = 2f;
    [Range(1f, 50f)] 
    [SerializeField] private float _yMultiplier = 2f;
    [Range(0f, 1f)] 
    [SerializeField] private float _curveSmoothness = 0.5f;
    [SerializeField] private float _noiseStep = 0.5f;
    [SerializeField] private float _bottom = 10f;

    [Header("Collectables")]
    [Range(1, 100)]
    [SerializeField] private int _collectablesRate = 30;
    [SerializeField] private List<CollectableData> _collectables;

    [Header("References")]
    [SerializeField] private SpriteShapeController _spriteShapeController;
    [SerializeField] private Transform _collectablesParent;

    private Vector3 _lastPos;
    private HashSet<Vector3> _shapePositions = new HashSet<Vector3>();

    private void OnValidate()
    {
        _spriteShapeController.spline.Clear();
        _shapePositions.Clear();

        for (int i = 0; i < _levelLength; i++) {
            _lastPos = transform.position + new Vector3(i * _xMultiplier, Mathf.PerlinNoise(0, i * _noiseStep) * _yMultiplier);
            _shapePositions.Add(_lastPos);
            _spriteShapeController.spline.InsertPointAt(i, _lastPos);

            if (i != 0 && i != _levelLength + 1) {
                _spriteShapeController.spline.SetTangentMode(i, ShapeTangentMode.Continuous);
                _spriteShapeController.spline.SetLeftTangent(i, Vector3.left * _xMultiplier * _curveSmoothness);
                _spriteShapeController.spline.SetRightTangent(i, Vector3.right * _xMultiplier * _curveSmoothness);
            }
        }

        _spriteShapeController.spline.InsertPointAt(_levelLength, new Vector3(_lastPos.x, transform.position.y - _bottom));

        _spriteShapeController.spline.InsertPointAt(_levelLength + 1, new Vector3(transform.position.x, transform.position.y - _bottom));
    }

    [ContextMenu("RespawnCollectables")]
    private void ReSpawnCollectables()
    {
        foreach (Transform collectable in _collectablesParent) {
            DestroyImmediate(collectable.gameObject);
        }

        foreach (Vector3 shapePosition in _shapePositions) {
            if (Random.Range(1, 100) < _collectablesRate) {
                Instantiate(GetRandomCollectable(), new Vector3(shapePosition.x, shapePosition.y + 2), Quaternion.identity, _collectablesParent);
                print(shapePosition);
            }
        }
    }

    private GameObject GetRandomCollectable()
    {
        float collactableRate = _collectables.Sum(collectable => collectable.SpawnRate);
        float _collectableRandomNumber = Random.Range(0f, collactableRate);

        foreach (CollectableData collectable in _collectables) {
            collactableRate -= collectable.SpawnRate;
            if (_collectableRandomNumber > collactableRate) {
                return collectable.Prefab;
            }
        }
 
        return null;
    }

    [System.Serializable]
    private class CollectableData
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField] private float _spawnRate;

        public GameObject Prefab => _prefab;
        public float SpawnRate => _spawnRate;
    }
}
