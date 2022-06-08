using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item_UI : MonoBehaviour
{
    private List<Item_UI> childList;

    public Button itemArrow;
    public Sprite down, right;
    public Text text;
    public bool isOpen { get; set; }
    private Vector2 startSize;


    private void Awake()
    {
        childList = new List<Item_UI>();
        itemArrow.onClick.AddListener(() =>
        {
            if (isOpen)
            {
                CloseChild();
                isOpen = false;
            }
            else
            {
                OpenChild();
                isOpen = true;
            }
        });
        startSize = this.GetComponent<RectTransform>().sizeDelta;
        isOpen = false;
    }

    public void InitPanelContent(Item item)
    {
        text.text = item.name;
    }

    private void AddChild(Item_UI parentItemUI)
    {
        childList.Add(parentItemUI);
        if (childList.Count >= 1)
        {
            itemArrow.GetComponent<Image>().sprite = right;
        }
    }

    public void SetItemParent(Item_UI parentItemUI)
    {
        this.transform.SetParent(parentItemUI.transform);
        parentItemUI.AddChild(this);
        this.GetComponentInChildren<VerticalLayoutGroup>().padding = new RectOffset((int)parentItemUI.itemArrow.GetComponent<RectTransform>().sizeDelta.x, 0, 0, 0);
        if (parentItemUI.isOpen)
        {

            this.GetComponent<Item_UI>().AddParentSize((int)this.gameObject.GetComponent<RectTransform>().sizeDelta.y);
        }
        else
        {
            this.transform.gameObject.SetActive(false);
        }
    }
    public void AddParentSize(int offset)
    {
        if (transform.parent.GetComponent<Item_UI>() != null)
        {
            transform.parent.GetComponent<Item_UI>().UpdateRectTranSize(offset);
            transform.parent.GetComponent<Item_UI>().AddParentSize(offset);
        }
    }
    public void SetBaseParent(Transform trans)
    {
        transform.SetParent(trans);
    }

    public void UpdateRectTranSize(int offset)
    {
        gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(startSize.x, gameObject.GetComponent<RectTransform>().sizeDelta.y + offset);
    }

    public void CloseChild()
    {
        if (childList.Count == 0)
            return;
        foreach (Item_UI child in childList)
        {
            child.gameObject.SetActive(false);
            child.GetComponent<Item_UI>().AddParentSize(-(int)child.gameObject.GetComponent<RectTransform>().sizeDelta.y);
        }
        itemArrow.GetComponent<Image>().sprite = right;
    }
    public void OpenChild()
    {
        if (childList.Count == 0)
            return;
        foreach (Item_UI child in childList)
        {
            child.gameObject.SetActive(true);
            child.GetComponent<Item_UI>().AddParentSize((int)child.gameObject.GetComponent<RectTransform>().sizeDelta.y);
        }
        itemArrow.GetComponent<Image>().sprite = down;
    }
}
