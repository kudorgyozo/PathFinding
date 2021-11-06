using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class NodeBuilder : MonoBehaviour
{

    public LayerMask layerMask;
    public int spacing = 1;
    public int maxSize = 5;
    public float nodeSize = 0.15f;

    public PFNode[,] nodes;
    [HideInInspector]
    public Vector3 nullNode = new Vector3(500, 500, 500);

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start");
    }

    public void BuildNodes()
    {
        Debug.Log("BuildNodes");
        nodes = new PFNode[maxSize, maxSize];
        RaycastHit hit;
        Vector3 dir = Vector3.down;

        for (int x = 0; x < maxSize; x++)
        {
            for (int y = 0; y < maxSize; y++)
            {
                Vector3 rayStart = new Vector3(transform.position.x + spacing * x, 1, transform.position.z + spacing * y);

                if (Physics.Raycast(new Ray(rayStart, dir), out hit, 100, layerMask))
                {
                    var tileGameObject = hit.collider.gameObject;
                    nodes[x, y].gameObject = tileGameObject;
                    var tileInfo = tileGameObject.GetComponentInParent<TileInfo>();
                    tileInfo.gridX = x;
                    tileInfo.gridY = y;
                }
                else
                {
                    //TODO: eleg ez?
                }
                //nodes[x, y].x = x;
                //nodes[x, y].y = y;
            }
        }

    }
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse is down");

            RaycastHit hitInfo;
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo, 100, layerMask);
            if (hit)
            {
                GameObject tileGameObject = hitInfo.transform.gameObject;
                TileInfo tileInfo = tileGameObject.GetComponentInParent<TileInfo>();

                //get pfNode
                Debug.Log("Hit " + hitInfo.transform.gameObject.name);
                Debug.Log($"TileInfo {tileInfo.gridX} {tileInfo.gridY} {tileInfo.chance}");
            }
            else
            {
                Debug.Log("No hit");
            }
            Debug.Log("/Mouse is down");
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        //Gizmos.DrawCube(transform.position, new Vector3(0.25f, 0.25f, 0.25f));
        if (nodes == null) return;

        for (int x = 0; x < maxSize; x++)
        {
            for (int y = 0; y < maxSize; y++)
            {
                if (nodes[x,y].gameObject != null)
                {
                    Gizmos.DrawCube(nodes[x, y].gameObject.transform.position, new Vector3(nodeSize, nodeSize, nodeSize));
                    Handles.Label(nodes[x, y].gameObject.transform.position, $"x: {x} y: {y}\n af");
                }
                    
            }
        }

    }

}
