using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestItemDrop : MonoBehaviour
{
    public ItemObject item;
    public GameObject slot;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            item.InstantiatePref(transform.position);
        }    

        Vector3 mousePosRight = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePosRight.x, mousePosRight.y);
        RaycastHit2D[] hits = Physics2D.RaycastAll(mousePos2D, Vector2.zero);

        if (Input.GetMouseButtonDown(0))
        {
            foreach (var hit in hits)
            {
                //Debug.Log(hit.collider.name);
                if (hit.collider.name.Contains("Item")) 
                {
                    CommonItemObject common = (CommonItemObject)hit.collider.gameObject.GetComponent<ItemCell>().item;
                    var rt = slot.GetComponent<RectTransform>();
                    rt.sizeDelta = new Vector2(40, 80);
                    rt.localPosition = new Vector3(rt.localPosition.x, rt.localPosition.y - 20, rt.localPosition.z);
                    slot.GetComponent<Image>().sprite = common.inventoryData.inventorySprite;
                    //Debug.Log(common.testData);
                }
            }
        }
    }
}
