using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

public class LevelController : MonoBehaviour
{
    

    [SerializeField] private EnemySpawn enemySpawn;

    [SerializeField] private GameObject[] Columns;

    public Dictionary<string, GameObject> dict = new Dictionary<string, GameObject>();
    [SerializeField] private int maxDepth;

    [SerializeField] private GameObject verticalWall; 
    [SerializeField] private GameObject horizontalWall; 
    [SerializeField] private GameObject leftDoor;
    [SerializeField] private GameObject rightDoor; 
    [SerializeField] private GameObject topDoor;
    [SerializeField] private GameObject bottomDoor;
    [SerializeField] private GameObject floor;

    [SerializeField] private NavMeshSurface surface2D;
    [SerializeField] private Transform layout;

    [SerializeField] private LayerMask floorLayer;
    // Start is called before the first frame update
    void Start()
    {
        GameObject newFloor =  Instantiate(floor, transform.position, Quaternion.identity, layout);
        Room newRoom = newFloor.AddComponent<Room>();
        newRoom.SetRoomWalls(new RoomWalls(false));
        surface2D.BuildNavMesh();
    }

    public Dictionary<string, GameObject> GetWalls()
    {
        dict["verticalWall"] = verticalWall;
        dict["horizontalWall"] = horizontalWall;
        dict["leftDoor"] = leftDoor;
        dict["rightDoor"] = rightDoor;
        dict["topDoor"] = topDoor;
        dict["bottomDoor"] = bottomDoor;

        return dict;
    } 

    public GameObject GetRandomColumn()
    {
        return Columns[Random.Range(0, 6)];
    }

    public GameObject getFloor()
    {
        return floor;
    }
   
    public int GetDepth()
    {
        return maxDepth;
    }

    public LayerMask GetMask()
    {
        return floorLayer;
    }

    public void NavMeshUpDate()
    {
        surface2D.UpdateNavMesh(surface2D.navMeshData);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public GameObject CallEnemySpawn(int depth)
    {
        return enemySpawn.GetEnemies(depth);
    } 

    public Transform GetLayout()
    {
        return layout;
    }
}
