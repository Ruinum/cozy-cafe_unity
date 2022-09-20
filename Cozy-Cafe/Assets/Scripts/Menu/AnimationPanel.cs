using Ruinum.Core;
using UnityEngine;


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
        TimerManager.Singleton.StartTimer(1f, () => SceneTransition.Singleton.SwitchToScene("GameplayScene"));
    }
}
