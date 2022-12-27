using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{

     public Dictionary<string, GameObject> dict = new Dictionary<string, GameObject>();
    [SerializeField] private int maxDepth;

    [SerializeField] private GameObject verticalWall; 
    [SerializeField] private GameObject horizontalWall; 
    [SerializeField] private GameObject leftDoor;
    [SerializeField] private GameObject rightDoor; 
    [SerializeField] private GameObject topDoor;
    [SerializeField] private GameObject bottomDoor;
    [SerializeField] private GameObject floor;

    // Start is called before the first frame update
    void Start()
    {
        GameObject newFloor =  Instantiate(floor, transform.position, Quaternion.identity);
        Room newRoom = newFloor.AddComponent<Room>();
        newRoom.SetRoomWalls(new RoomWalls(false));
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

    public GameObject getFloor()
    {
        return floor;
    }
   
    public int GetDepth()
    {
        return maxDepth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
