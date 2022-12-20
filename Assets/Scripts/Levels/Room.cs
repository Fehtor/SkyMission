using System.Collections.Generic;
using UnityEngine;

public enum RoomWallType
{
    Door,
    Wall,
    None
}

public class RoomWalls {

    public RoomWallType topWall;
    public RoomWallType bottomWall;
    public RoomWallType rightWall;
    public RoomWallType leftWall;

    public RoomWalls()
    {
        topWall = RoomWallType.None;
        bottomWall = RoomWallType.None;
        rightWall = RoomWallType.None;
        leftWall = RoomWallType.None;
    }

}

public class Room : MonoBehaviour
{
    
    public RoomWalls roomWalls;
    private LevelController controller;

    public Room()
    {
        roomWalls = new RoomWalls();
    }

    private void GenerateWalls()
    {
        if(roomWalls.topWall == RoomWallType.None)
        {
            roomWalls.topWall = GenerateWall();
        }
        
        if(roomWalls.bottomWall == RoomWallType.None)
        {
            roomWalls.bottomWall = GenerateWall();
        }
        
        if(roomWalls.rightWall == RoomWallType.None)
        {
            roomWalls.rightWall = GenerateWall();
        }
        
        if(roomWalls.leftWall == RoomWallType.None)
        {
            roomWalls.leftWall = GenerateWall();
        }

        Debug.Log($"{roomWalls.topWall} {roomWalls.rightWall} {roomWalls.bottomWall} {roomWalls.leftWall}");
        SpawnWall();
}

    private RoomWallType GenerateWall()
    {
        int number = Random.Range(0, 2);

        return number == 0 ? RoomWallType.Wall : RoomWallType.Door;
    }

    private void SpawnWall()
    {
        
        Vector3 horizontalRightGap =  new Vector3(14.6f, 0.004f, 0);
        Vector3 horizontalLeftGap =  new Vector3(14.65f, 0.004f, 0);
        Vector3 horizontalRightWallGap =  new Vector3(13f, -0.6f, 0);
        Vector3 horizontalLeftWallGap =  new Vector3(13.1f, 0.6f, 0);
        Vector3 verticalBottomGap =  new Vector3(0.1f, 6.9f, 0f);
        Vector3 verticalUpGap =  new Vector3(-0.35f, 7.1f, 0f);
        

        Dictionary<string, GameObject> dict = controller.GetWalls();


        if(roomWalls.topWall == RoomWallType.Door) { Instantiate(dict["topDoor"], controller.transform.position + verticalUpGap, Quaternion.identity); };
        if(roomWalls.bottomWall == RoomWallType.Door) { Instantiate(dict["bottomDoor"], controller.transform.position - verticalBottomGap, Quaternion.identity); };
        if(roomWalls.rightWall == RoomWallType.Door) { Instantiate(dict["rightDoor"], controller.transform.position - horizontalRightGap, Quaternion.identity); };
        if(roomWalls.leftWall == RoomWallType.Door) { Instantiate(dict["leftDoor"], controller.transform.position + horizontalLeftGap, Quaternion.identity); };


        if (roomWalls.topWall == RoomWallType.Wall) { Instantiate(dict["horizontalWall"], controller.transform.position + verticalUpGap, Quaternion.identity); };
        if (roomWalls.bottomWall == RoomWallType.Wall) { Instantiate(dict["horizontalWall"], controller.transform.position - verticalBottomGap, Quaternion.identity);  };
        if (roomWalls.rightWall == RoomWallType.Wall) { Instantiate(dict["verticalWall"], controller.transform.position - horizontalRightWallGap, Quaternion.identity); };
        if (roomWalls.leftWall == RoomWallType.Wall) { Instantiate(dict["verticalWall"], controller.transform.position + horizontalLeftWallGap, Quaternion.identity); };
    }

    

    public void SetRoomWalls(RoomWalls inp_RoomWalls)
    {
        Debug.Log("SetRoomWalsing");
        roomWalls = inp_RoomWalls;
    }
    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.FindGameObjectWithTag("LevelController").GetComponent<LevelController>();
        GenerateWalls();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
