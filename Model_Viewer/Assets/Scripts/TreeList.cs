using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeList : MonoBehaviour
{
    private List<GameObject> itemPanelList = new List<GameObject>();
    public GameObject itemPanel;
    Model_move Model;

    void Start()
    {
        Model = FindObjectOfType<Model_move>();

        GameObject newItemPanel = Instantiate(itemPanel);
        itemPanelList.Add(newItemPanel);
        newItemPanel.GetComponent<Item_UI>().SetBaseParent(this.transform);
        newItemPanel.GetComponent<Item_UI>().InitPanelContent(new Item(Model.ModelPartsName[0]));

        for (int i = 1; i < Model.ModelPartsName.Count - 1; i++)
        {
            GameObject newItemPanel2 = Instantiate(itemPanel);
            itemPanelList.Add(newItemPanel2);
            //newItemPanel2.GetComponent<Item_UI>().SetItemParent(itemPanelList[0].GetComponent<Item_UI>());
            newItemPanel2.GetComponent<Item_UI>().InitPanelContent(new Item(Model.ModelPartsName[i]));

        }
        itemPanelList[1].GetComponent<Item_UI>().SetItemParent(itemPanelList[0].GetComponent<Item_UI>());
        itemPanelList[6].GetComponent<Item_UI>().SetItemParent(itemPanelList[0].GetComponent<Item_UI>());
        itemPanelList[94].GetComponent<Item_UI>().SetItemParent(itemPanelList[0].GetComponent<Item_UI>());
        itemPanelList[116].GetComponent<Item_UI>().SetItemParent(itemPanelList[0].GetComponent<Item_UI>());


        for (int i = 2; i <= 5; i++)
        {
            itemPanelList[i].GetComponent<Item_UI>().SetItemParent(itemPanelList[1].GetComponent<Item_UI>());
        }
        for (int i = 7; i <= 93; i++)
        {
            itemPanelList[i].GetComponent<Item_UI>().SetItemParent(itemPanelList[6].GetComponent<Item_UI>());
        }
        for (int i = 94; i <= 115; i++)
        {
            itemPanelList[i].GetComponent<Item_UI>().SetItemParent(itemPanelList[94].GetComponent<Item_UI>());
        }
        for (int i = 117; i < 138; i++)
        {
            itemPanelList[i].GetComponent<Item_UI>().SetItemParent(itemPanelList[116].GetComponent<Item_UI>());
        }

    }
}
