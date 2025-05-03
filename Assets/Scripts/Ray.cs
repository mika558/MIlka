using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ray : MonoBehaviour
{

    private LineRenderer laserRenderer;
    public LayerMask layerMask;
    private int laserDistance = 30;
    private int numberReflectMax = 30;
    private Vector3 pos = new Vector3();
    private Vector3 directLaser = new Vector3();
    bool loopActive = true;
    //bool crossWin = false;
    //public Transform armGun;

    public lvlinfo lvlinfoScript;

    //gate
    public SpriteRenderer spriteRendererGate;
    public Sprite closeSpriteGate;
    public Sprite openSpriteGate;

    void Start()
    {
        laserRenderer = GetComponent<LineRenderer>();
    }
    void Update()
    {
        DrawLaser();
    }
    void DrawLaser()
    {
        loopActive = true;
        int countLaser = 1;

        pos = transform.position;
        directLaser = transform.right;
        laserRenderer.positionCount = countLaser;
        laserRenderer.SetPosition(0, pos);
        //float angle = Mathf.Atan2(directLaser.y, directLaser.x) * 180 / Mathf.PI;
        //armGun.transform.rotation = Quaternion.AngleAxis(angle, new Vector3(0, 0, 1));

        //laserRenderer.startWidth = 0.025f;
        //laserRenderer.endWidth = 0.025f;
        laserRenderer.startColor = Color.red;
        laserRenderer.endColor = Color.yellow;

        while (loopActive)
        {
            RaycastHit2D hit = Physics2D.Raycast(pos, directLaser, laserDistance, layerMask);
            if (hit)
            {
                countLaser++;
                laserRenderer.positionCount = countLaser;
                directLaser = Vector3.Reflect(directLaser, hit.normal);
                pos = (Vector2)directLaser.normalized + hit.point;
                laserRenderer.SetPosition(countLaser - 1, hit.point);

                if (hit.collider.CompareTag("EndLaser"))
                {
                    loopActive = false;
                    lvlinfoScript.SetLaserEndWin(true);
                    spriteRendererGate.sprite = openSpriteGate;

                }
                if (hit.collider.gameObject.layer == 3) //Ground
                {
                    loopActive = false;
                    lvlinfoScript.SetLaserEndWin(false);
                    spriteRendererGate.sprite = closeSpriteGate;

                }
            }
            else
            {
                countLaser++;
                laserRenderer.positionCount = countLaser;
                laserRenderer.SetPosition(countLaser - 1, pos + (directLaser.normalized * laserDistance));
                
                loopActive = false;
                lvlinfoScript.SetLaserEndWin(false);
                spriteRendererGate.sprite = closeSpriteGate;

            }


            if (countLaser > numberReflectMax)
            {
                loopActive = false;
                lvlinfoScript.SetLaserEndWin(false);
                spriteRendererGate.sprite = closeSpriteGate;

            }
        }


    }

}
