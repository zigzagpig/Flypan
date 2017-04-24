using UnityEngine;
using System.Collections;

public class FeipanManager : MonoBehaviour
{

    public GameObject prefab_Feipan;  //0
    public GameObject prefab_ds;      //1
    public GameObject prefab_zz;      //2
    public GameObject prefab_yy;      //3
    public GameObject prefab_xg;      //4
    public GameObject prefab_dd;      //5
    public GameObject prefab_dls;     //6
    public GameObject prefab_tx;      //7
    public GameObject prefab_yh;      //8
    private GameObject prefab_haha;

    private Transform m_Transform; 


	void Start ()
	{
	    m_Transform = gameObject.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        

    }

    public void StopCreateFeipan()
    {
        CancelInvoke();
    }

    public void StartCreateFeipan()
    {
        InvokeRepeating("CreateFeipan", 0.0f, 0.2f);
    }


    //创建生成飞盘
    void CreateFeipan()
    {
        //Vector3 position = new Vector3(Random.Range(-6.0f, 6.0f), Random.Range(0.5f, 5.5f), Random.Range(4.0f, 15.0f));
        ////实例化飞盘
        //GameObject.Instantiate(prefab_Feipan, position, Quaternion.identity);

        for (int i = 0; i < 1; i++)
        {
            int random = Random.Range(1, 1000) % 9;
            if(random == 0)
                prefab_haha = prefab_Feipan;
            else if (random == 1)
                prefab_haha = prefab_ds;
            else if (random == 2)
                prefab_haha = prefab_zz;
            else if (random == 3)
                prefab_haha = prefab_yy;
            else if (random == 4)
                prefab_haha = prefab_xg;
            else if (random == 5)
                prefab_haha = prefab_dd;
            else if (random == 6)
                prefab_haha = prefab_dls;
            else if (random == 7)
                prefab_haha = prefab_tx;
            else if (random == 8)
                prefab_haha = prefab_yh;

            Vector3 position = new Vector3(Random.Range(-6.0f, 6.0f), Random.Range(0.5f, 5.5f), Random.Range(4.0f, 15.0f));
            //实例化飞盘
            GameObject go = GameObject.Instantiate(prefab_haha, position, Quaternion.identity) as GameObject;
            Destroy(go, 4.0f);
            go.GetComponent<Transform>().SetParent(m_Transform);
        }

        
    }

    public void RemoveFeipan()
    {
       Transform[] feipans = m_Transform.GetComponentsInChildren<Transform>();
        Debug.Log(feipans.Length);
        for (int i = 1; i < feipans.Length; i++)
        {
            GameObject.Destroy(feipans[i].gameObject);
        }
    }
}
