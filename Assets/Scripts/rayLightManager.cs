using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rayLightManager : MonoBehaviour
{
    static public rayLightManager instance;

    public GameObject LinePrefab;
    List<rayLight> lasers = new List<rayLight>();
    List<GameObject> lines = new List<GameObject>();

    int maxStepDistance = 20;
    public LayerMask layermask;


    public void AddLaser(rayLight laser) { lasers.Add(laser); }
    public void RemoveLaser(rayLight laser) { lasers.Remove(laser); }

    private int ind = 0;
    int result = 1;

    void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        
    }
    void RemoveOldLines(int linesCount)
    {
        if (linesCount < lines.Count)
        {
            Destroy(lines[lines.Count - 1]);
            lines.RemoveAt(lines.Count - 1);
            RemoveOldLines(linesCount);
        }

    }
    void Update()
    {
        ind = 0;
        int linesCount = 0;

        foreach (rayLight laser in lasers)
        {
            result = 1;
            linesCount += CalcLaserLine(laser.transform.position, laser.transform.right, linesCount);
        }
        RemoveOldLines(linesCount);
    }

    int CalcLaserLine(Vector3 startPosition, Vector3 direction, int index)
    {
        //int result = 1;
        //ind++;

        ////RaycastHit2D hit;
        ////Ray2D ray = new Ray2D(startPosition, direction);
        //Debug.DrawRay(startPosition, direction * maxStepDistance, Color.red);
        //RaycastHit2D hit = Physics2D.Raycast(startPosition, direction, maxStepDistance, layermask);
        //Vector2 hitPosition = hit.point;

        //if (hit.collider == null) { hitPosition = startPosition + direction * maxStepDistance; }
        //DrawLine(startPosition, hitPosition, index);
        //if (ind < 10)
        //{
        //    if (hit.collider != null)
        //    {
        //        result += CalcLaserLine(hitPosition, Vector2.Reflect(direction, hit.normal), result + index);
        //    }
        //}

        //return result;
        Physics2D.queriesStartInColliders = false;
        ind++;
        RaycastHit2D hitinfo = Physics2D.Raycast(startPosition, direction, maxStepDistance, layermask);
        Debug.DrawRay(startPosition, direction * maxStepDistance, Color.yellow);

        bool intersect;
        if (hitinfo.collider != null)
        {
            intersect = true;
        }
        else
        {
            intersect = false;

        }
        Debug.Log(hitinfo.point);
        Vector3 hitPosition = hitinfo.point;
        
        if (!intersect) { hitPosition = startPosition + (direction * maxStepDistance); }

        DrawLine(startPosition, hitPosition, index);
        if (ind < 10)
        {
            if (intersect)
            {
                //Debug.Log(hit.collider.name);
                if (!hitinfo.collider.OverlapPoint(hitPosition))
                {
                    Debug.DrawRay(hitPosition, Vector2.Reflect(direction, hitinfo.normal).normalized, Color.red);
                    result += CalcLaserLine(hitPosition, Vector2.Reflect(direction, hitinfo.normal).normalized, index + result);
                }
            }
        }
        //Debug.Log(hitPosition);
        return result;
    }
    void DrawLine(Vector3 startPosition, Vector3 finishPosition, int index)
    {
        LineRenderer line = null;
        if (index < lines.Count)
        {
            line = lines[index].GetComponent<LineRenderer>();
        }
        else
        {
            GameObject go = Instantiate(LinePrefab, Vector3.zero, Quaternion.identity);
            line = go.GetComponent<LineRenderer>();
            lines.Add(go);
        }

        line.SetPosition(0, startPosition);
        line.SetPosition(1, finishPosition);


    }
}




////////////////////////////////////////////

//static public rayLightManager instance;

//    public GameObject LinePrefab;
//    List<rayLight> lasers = new List<rayLight>();
//    List<GameObject> lines = new List<GameObject>();

//    int maxStepDistance = 20;
//    public LayerMask layermask;

//    public void AddLaser(rayLight laser) { lasers.Add(laser); }
//    public void RemoveLaser(rayLight laser) { lasers.Remove(laser); }

//    int ind = 0;
//    void Awake()
//    {
//        instance = this;
//    }

//    void RemoveOldLines()
//    {
//        if (lines.Count > 0)
//        {
//            Destroy(lines[lines.Count - 1]);
//            lines.RemoveAt(lines.Count - 1);
//            RemoveOldLines();
//        }

//    }
//    void Update()
//    {

//        ind = 0;
//        Debug.Log(ind);
//        RemoveOldLines();
//        foreach (rayLight laser in lasers)
//        {
//            CalcLaserLine(laser.transform.position, laser.transform.right);
//        }
        
//    }

//    void CalcLaserLine(Vector2 startPosition, Vector2 direction)
//    {



//        //RaycastHit2D hit;
//        //Ray2D ray = new Ray2D(startPosition, direction);
//        Debug.DrawRay(startPosition, direction * 20, Color.red);
//        RaycastHit2D hit = Physics2D.Raycast(startPosition, direction, maxStepDistance, layermask);
//        Vector2 hitPosition = hit.point;

//        if (hit.collider == null) { hitPosition = startPosition + direction * maxStepDistance;}
//        DrawLine(startPosition, hitPosition);

//        if (ind < 10)
//        {
//            if (hit.collider != null)
//            {
//                ind++;
//                Debug.DrawRay(hitPosition, Vector2.Reflect(direction, hit.normal) * 10, Color.red);
//                Debug.Log("hit: " + ind);
//                CalcLaserLine(hitPosition, Vector2.Reflect(direction, hit.normal));
//                //MakeNewRay(hitPosition, Vector2.Reflect(direction, hit.normal));
//            }
//        }


//    }

//    void DrawLine(Vector2 startPosition, Vector2 finishPosition)
//    {
//        GameObject go = Instantiate(LinePrefab, Vector2.zero, Quaternion.identity);
//        LineRenderer line = go.GetComponent<LineRenderer>();
//        lines.Add(go);

//        line.SetPosition(0, startPosition);
//        line.SetPosition(1, finishPosition);


//    }
//}
