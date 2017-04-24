using System;
using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{

    private Ray ray;
    private RaycastHit raycastHit;

    private Transform mTransform;
    private Transform mPointTransform;
    private LineRenderer lineRenderer;

    private AudioSource audioSource;

    private bool canMove = false;

    private GameManager m_GameManager;


    public int[] hash = new int[20];
    public float count = 0f;


    void Start ()
	{
	    mTransform = gameObject.GetComponent<Transform>();
	    //mPointTransform = GameObject.Find("Point").GetComponent<Transform>();
	    mPointTransform = mTransform.FindChild("Point");
	    lineRenderer = mPointTransform.gameObject.GetComponent<LineRenderer>();
	    audioSource = gameObject.GetComponent<AudioSource>();
	    m_GameManager = GameObject.Find("UI").GetComponent<GameManager>();
    }

    public void ChangeCanMove(bool state)
    {
        canMove = state;
    }

    public int[] ReturnHash()
    {
        return hash;
    }

    public float ReturnCount()
    {
        return count;
    }

    // Update is called once per frame
    void Update ()
	{
	    if (canMove == true)
	    {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out raycastHit))
            {
                //控制手臂朝向碰撞点
                mTransform.LookAt(raycastHit.point);
                //控制测试线
                //Debug.DrawLine(mPointTransform.position, raycastHit.point, Color.red);
                //设置LineRenderer位置
                lineRenderer.SetPosition(0, mPointTransform.position);
                lineRenderer.SetPosition(1, raycastHit.point);

                //飞盘射击
                if (raycastHit.collider.tag == "Feipan" && Input.GetMouseButtonDown(0))
                {
                    //Debug.Log(raycastHit.collider.name);
                    if (raycastHit.collider.gameObject.GetComponent<Rigidbody>() == null)
                    {
                        audioSource.Play();
                        m_GameManager.AddScore();


                        //通过碰到的子物体查找到该子物体的父物体
                        Transform parent = raycastHit.collider.gameObject.GetComponent<Transform>().parent;
                        Debug.Log(Convert.ToInt32(parent.name[0]));
                        Debug.Log(parent.name[0]);
                        count = count +1;
                        hash[int.Parse(parent.name[0]+"")]++;

                        //通过父物体查找到所有子物体
                        Transform[] feipans = parent.GetComponentsInChildren<Transform>();
                        for (int i = 0; i < feipans.Length; i++)
                        {
                            //给子物体添加刚体
                            feipans[i].gameObject.AddComponent<Rigidbody>();
                        }
                        GameObject.Destroy(parent.gameObject, 2.0f);
                    }
                }

            }
            else
            {
                Debug.Log("没碰到东西");
            }
        }
	}
}
