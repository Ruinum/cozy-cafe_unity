using Ruinum.Core;
using UnityEngine;


public class AnimationPanel : MonoBehaviour
{
    //ЗАПУСК АНИМАЦИЙ
    public void Animate_Panel()//Открывает (визуально) меню настроек 
    {
        GetComponent<Animation>().Play("Settings Open");
    }
    public void Close_Panel()//Закрывает (визуально) меню настроек 
    {
        GetComponent<Animation>().Play("Settings Close");
    }

    public void Animate_Transition()//Переходит (визуально) в игру
    {
        GetComponent<Animation>().Play("Black_animation");
        TimerManager.Singleton.StartTimer(1f, () => SceneTransition.Singleton.SwitchToScene("GameplayScene"));
    }
}
