using System.Collections.Generic;
using _GAME_.Scripts.Actions;
using Singleton;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleManager : NonPersistentSingleton<ObstacleManager>
{
    public int obstaclePoolSize = 15;
    public ObstacleBehaviour ObstaclePrefab;
    private List<ObstacleBehaviour> _obstacles;
    private BackgroundMovement _backgroundMovement;
    private Transform rightMostTransform;
    private float _startX;
    private bool shouldMove;
    public Transform nextHolePos;
    private int nextObstacleIndex;
    private float posX;
    private void OnEnable()
    {
        GameFlow.levelStarted += StartMoving;
        GameFlow.levelFailed += StopMoving;
        GameFlow.passedObstacle += UpdateNextObstacle;
        GameFlow.levelRestarted += ResetVariables;
    }


    private void OnDisable()
    {
        GameFlow.levelStarted -= StartMoving;
        GameFlow.levelFailed -= StopMoving;
        GameFlow.passedObstacle -= UpdateNextObstacle;
        GameFlow.levelRestarted -= ResetVariables;
    }

    private void ResetVariables()
    {
        if (_backgroundMovement == null)
        {
            _startX = 6f;
        }
        else
        {
            _startX = _backgroundMovement.DiffX;
        }
        posX = _startX;
        for (int i = 0; i < obstaclePoolSize; i++)
        {
            Destroy(_obstacles[i].gameObject);
            
        }
        _obstacles.Clear();
        CreateObstacles();
    }

    private void UpdateNextObstacle()
    {
        nextObstacleIndex = (nextObstacleIndex + 1) % _obstacles.Count;
        nextHolePos.position = _obstacles[nextObstacleIndex].GetCenter();
    }
    private void StopMoving()
    {
        shouldMove = false;
    }

    private void StartMoving()
    {
        shouldMove = true;
    }
    void Start()
    {
        _backgroundMovement = FindObjectOfType<BackgroundMovement>();
        if (_backgroundMovement == null)
        {
            _startX = 6f;
        }
        else
        {
            _startX = _backgroundMovement.DiffX;
        }
        _obstacles = new List<ObstacleBehaviour>();
        posX = _startX;
        CreateObstacles();
    }

    private void CreateObstacles()
    {
        for (int i = 0; i < obstaclePoolSize; i++)
        {
            _obstacles.Add(Instantiate(ObstaclePrefab, GetRandomSpawnVectorWithX(posX), Quaternion.identity));
            _obstacles[i].OpenHoleWithSize(Random.Range(GameSettings.MinHoleSize, GameSettings.MaxHoleSize));
            posX += Random.Range(GameSettings.MinXDistObstacle, GameSettings.MaxXDistObstacle);
        }

        nextHolePos.position = _obstacles[0].GetCenter();
        rightMostTransform = _obstacles[obstaclePoolSize - 1].transform;
    }

    private Vector3 GetRandomSpawnVectorWithX(float posX)
    {
        return new Vector3(posX, Random.Range(GameSettings.MinYObstacle, GameSettings.MaxYObstacle), 0);
    }

    private void Update()
    {
        if(!shouldMove) return;
        for (int i = 0; i < obstaclePoolSize; i++)
        {
            _obstacles[i].transform.Translate(Vector3.left * (Time.deltaTime * GameSettings.HorizontalMovementSpeed));
        }
        for (int i = 0; i < obstaclePoolSize; i++)
        {
            if (_obstacles[i].transform.position.x < -_startX)
            {
                MoveIthObstacleToEnd(i);
            }
        }
    }

    private void MoveIthObstacleToEnd(int i)
    {
        _obstacles[i].transform.position = GetRandomSpawnVectorWithX(rightMostTransform.position.x + Random.Range(GameSettings.MinXDistObstacle, GameSettings.MaxXDistObstacle));
        _obstacles[i].OpenHoleWithSize(Random.Range(GameSettings.MinHoleSize, GameSettings.MaxHoleSize));
        rightMostTransform = _obstacles[i].transform;
    }
}
