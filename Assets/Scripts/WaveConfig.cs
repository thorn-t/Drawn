using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] Transform startingPathPrefab;
    //[SerializeField] Transform endingPathPrefab;
    [SerializeField] float moveSpeed = 5f;

    public Transform GetStartingWaypoint()
    {
        return startingPathPrefab.GetChild(0);
    }

    public List<Transform> GetWaypoints()
    {;
        List<Transform> waypoints = new List<Transform>();
        foreach (Transform child in startingPathPrefab)
        {
            waypoints.Add(child);
        }
        return waypoints;
    }

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }
}
