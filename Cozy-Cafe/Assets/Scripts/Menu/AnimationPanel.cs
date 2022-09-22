using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ruinum.Core;

public class AnimationPanel : MonoBehaviour
{
    //������ ��������
    public void Animate_Panel()//��������� (���������) ���� �������� 
    {
        GetComponent<Animation>().Play("Settings Open");
    }
    public void Close_Panel()//��������� (���������) ���� �������� 
    {
        GetComponent<Animation>().Play("Settings Close");
    }

    public void Animate_Transition()//��������� (���������) � ����
    {
        GetComponent<Animation>().Play("Black_animation");
        TimerManager.Singleton.StartTimer(1, () => SceneTransition.Singleton.SwitchToScene("Gameplay_Core"));
    }

    
}
