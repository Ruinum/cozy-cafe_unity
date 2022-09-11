using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelOpener : MonoBehaviour
{
    public GameObject Panel;

    public void OpenPanel()
    {
        if (Panel != null)
        {
            Panel.SetActive(true);
        }
        
    }
    public void ClosePanel()
    {
        if (Panel != null)
        {
            Debug.Log('1');
            IEnumerator ButtonDelay()
            {
                Debug.Log('2');
                yield return new WaitForSeconds(2);
                Debug.Log('3');
                Panel.SetActive(false);
                Debug.Log('4');
            }
            Debug.Log('5');


        }

    }

}
