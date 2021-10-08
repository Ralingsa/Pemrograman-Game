using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createItems : MonoBehaviour
{
    public GameObject item;
    public int cost = 100;
    private Vector3 screemPoint;
    private Vector3 offset;

    private void OnMouseDown()
    {
        if (Data.coin > cost)
        {
            Debug.Log("create item");
            GameObject _item = (GameObject)Instantiate(item, transform.position, Quaternion.identity);
            foreach (Behaviour childComponent in _item.GetComponentsInChildren<Behaviour>())
                childComponent.enabled = false;
            screemPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
            offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                Input.mousePosition.y, screemPoint.z));
            dragDrop dd = _item.GetComponent<dragDrop>();
            dd.enabled = true;
            dd.screenPoint = screemPoint;
            dd.offset = offset; ;
            dd.cost = cost;
        }
        else
        {
            Debug.Log("koin tidak cukup");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
