using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Img_CB_change : MonoBehaviour
{
    public TextMeshProUGUI describe_text;
    public TextMeshProUGUI instuct_text;
    public int index_current;
    public int length;
    public Image Curr_Img;
    List<string> descriptions = new List<string>() { "1)Latte\nGood" };
    List<string> instructions = new List<string>() { "1)Step one1\n2)Step two1" };
    public Sprite img_0;
    public Sprite img_1;
    public Sprite img_2;



    void Awake()
    {
        descriptions.Add("2)Coffee\nGood");
        descriptions.Add("3)Espresso\nGood");

        instructions.Add("1)Step one2\n2)Step two2");
        instructions.Add("1)Step one3\n2)Step two3");

        instuct_text.text = instructions[0];
        describe_text.text = descriptions[0];

        length = descriptions.Count;

        index_current = 0;

        Curr_Img.sprite = img_0;
    }
    
    
    public void NextText()
    {
        if (length > 0)
        {
            index_current = (index_current + 1) % length;
            instuct_text.text = instructions[index_current];
            describe_text.text = descriptions[index_current];

            if (index_current == 2)
            {
                Curr_Img.sprite = img_2;
            }
            if (index_current == 1)
            {
                Curr_Img.sprite = img_1;
            }
            if (index_current == 0)
            {
                Curr_Img.sprite = img_0;
            }
        }

    }
    public void PrevText() //если листать назад, то все немного криво, ибо 2 разные кнопки, Awake срабатывает снова и все печально. я не знаю как это починить :(
    {
        index_current= index_current-1;
        if (index_current == -1)
        {
            Debug.Log("True");
            index_current = length-1;
        }
        instuct_text.text = instructions[index_current];
        describe_text.text = descriptions[index_current];

        if (index_current == 2)
        {
            Curr_Img.sprite = img_2;
        }
        if (index_current == 1)
        {
            Curr_Img.sprite = img_1;
        }
        if (index_current == 0)
        {
            Curr_Img.sprite = img_0;
        }

    }
}
