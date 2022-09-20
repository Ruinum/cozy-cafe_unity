using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;


public class Img_CB_change : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _description;
    [SerializeField] private Transform _layoutGroup;

    [SerializeField] private GameObject _itemUIPrefab;

    [SerializeField] private ReceptSO[] _receptSOs;

    private List<GameObject> _createdRecepts = new List<GameObject>();

    private int _index = 0;

    public void Open()
    {
        gameObject.SetActive(true);
        SetInformation(_receptSOs[_index]);
    }

    public void NextRecept()
    {
        if (_index + 1 > _receptSOs.Length) return;
        
        _index++;

        SetInformation(_receptSOs[_index]);
    }

    public void PreviousRecept() 
    {
        if (_index - 1 < 0) return;

        _index--;

        SetInformation(_receptSOs[_index]);
    }

    private void SetInformation(ReceptSO receptSO)
    {
        _image.sprite = receptSO.ResultItem.Icon;
        _name.text = receptSO.ResultItem.Name;
        _description.text = receptSO.ResultItem.Description;

        for (int i = 0; i < _createdRecepts.Count; i++)
        {
            Destroy(_createdRecepts[i]);
        }

        for (int i = 0; i < receptSO.RequestItems.Length; i++)
        {
            var createdItemUI = Instantiate(_itemUIPrefab, _layoutGroup);
            createdItemUI.GetComponent<Image>().sprite = receptSO.RequestItems[i].Icon;
            _createdRecepts.Add(createdItemUI);
        }
    }
}
