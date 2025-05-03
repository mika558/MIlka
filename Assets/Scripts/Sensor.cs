using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{

    public float moveSpeed = 0.03f;
    //private bool move = true; // чтобы нужно было ждать, пока все стены встанут на свои места

    private GameObject ParentOfSensor;

    private GameObject[] AllMoveWalls;
    private GameObject[] AllThisMoveWalls;
    private List<Transform> ThisMoveWalls = new List<Transform>(); // массив со стенами

    private GameObject[] AllPointsMoveWalls;
    private List<Transform> Points = new List<Transform>();
    private List<List<Transform>> PointsMoveWallsArray = new List<List<Transform>>(); // массив массивов с точками


    private List<int> MoveWallsDirection = new List<int>();// массив с точками, в которых находятся стены



    public Slimecat slimecatScript;

    void Start()
    {
        ParentOfSensor = transform.parent.gameObject; //основной объект

        AllMoveWalls = GameObject.FindGameObjectsWithTag("MoveWall");
        AllThisMoveWalls = GameObject.FindGameObjectsWithTag("ThisMoveWall");
        AllPointsMoveWalls = GameObject.FindGameObjectsWithTag("PointMoveWall");


        foreach (GameObject AllMoveWall in AllMoveWalls)
        {

            if (AllMoveWall.transform.parent.gameObject == ParentOfSensor)
            {
                //MoveWalls.Add(AllMoveWall.transform);
                foreach (GameObject AllThisMoveWall in AllThisMoveWalls)
                {
                    if (AllThisMoveWall.transform.parent.gameObject == AllMoveWall)
                    {

                        ThisMoveWalls.Add(AllThisMoveWall.transform);
                        MoveWallsDirection.Add(0);

                    }
                }


                Points = new List<Transform>();
                foreach (GameObject AllPointsMoveWall in AllPointsMoveWalls)
                {
                    if (AllPointsMoveWall.transform.parent.gameObject == AllMoveWall)
                    {
                        
                        Points.Add(AllPointsMoveWall.transform);

                    }
                }
                if (Points != null)
                {
                    PointsMoveWallsArray.Add(Points);

                }

            }
        }

    }

    void Update()
    {
        int j = 0;
        //Debug.Log(ThisMoveWalls.Count);
        for (int i = 0; i < ThisMoveWalls.Count; i++)
        {
            Vector2 here = ThisMoveWalls[i].position;
            Vector2 next = PointsMoveWallsArray[i][MoveWallsDirection[i]].position;
            //Debug.Log(i + ": this-" + ThisMoveWalls[i].position + "    next-" + PointsMoveWallsArray[i][MoveWallsDirection[i]].position);
            //Debug.Log(i + ": this-" + here + "    next-" + next);
            Vector2 diff = here - next;
            if (diff.magnitude <= 0.1f)
            {
                ThisMoveWalls[i].position = next;
            }
            if (here != next)
            {
                //Debug.Log("Едем");
                ThisMoveWalls[i].position = Vector2.MoveTowards(ThisMoveWalls[i].position, PointsMoveWallsArray[i][MoveWallsDirection[i]].position, moveSpeed);

                //Debug.Log(Vector2.MoveTowards(ThisMoveWalls[i].position, PointsMoveWallsArray[i][nextPosition].position, moveSpeed));
            }
            else
            {

                j++;

            }
        }
        Debug.Log(j + " из " + ThisMoveWalls.Count);
        if (j == ThisMoveWalls.Count)
        {
            slimecatScript.ChangeSensorActive();
        }

    }
    public void MoveWallsMethod()
    {
        //Debug.Log("MoveWallsMethod");
        for (int i = 0; i < MoveWallsDirection.Count; i++)
        {
            if (MoveWallsDirection[i] < PointsMoveWallsArray[i].Count - 1)
            {
                MoveWallsDirection[i] = MoveWallsDirection[i] + 1;
            }
            else
            {
                MoveWallsDirection[i] = 0;
            }

            //Debug.Log(i + ": " + MoveWallsDirection[i]);
        }

    }

}
