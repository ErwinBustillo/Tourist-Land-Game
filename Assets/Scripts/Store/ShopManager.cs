using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour {

    public RectTransform viewPort;
    public RectTransform scrollviewContent;

	public List<GameObject> itemsParaComprar;

    private void Start()
    {
        StartCoroutine(LoadItems());
        for (int index = 0; index < itemsParaComprar.Count; index++)
        {
            Instantiate(itemsParaComprar[index]).transform.SetParent(scrollviewContent);
        }
        viewPort.anchoredPosition = viewPort.parent.position;
        viewPort.anchorMin = new Vector2(1, 0);
        viewPort.anchorMax = new Vector2(0, 1);
        viewPort.pivot = new Vector2(0.5f, 0.5f);
        viewPort.sizeDelta = viewPort.parent.GetComponent<RectTransform>().rect.size;
        viewPort.transform.SetParent(viewPort.parent);
    }

    IEnumerator LoadItems()
    {
        int index = 0;
        while (true)
        {
            Instantiate(itemsParaComprar[index]).transform.SetParent(scrollviewContent);
            if (index < itemsParaComprar.Count)
                index++;

            else
                yield break;

            yield return null;
        }
    }


}
