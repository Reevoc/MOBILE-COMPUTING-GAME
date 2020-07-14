using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessagePanelController : MonoBehaviour
{
    /** il pannello dei messsaggi dopo 5 secondi deve sparire */

    // Start is called before the first frame update
    void Start()
    {
    }

    public void dismissPanel()
    {
        StartCoroutine(this.dismissPanel0());
    }

    private IEnumerator dismissPanel0()
    {
        yield return new WaitForSeconds(5);
        gameObject.SetActive(false);
    }
}
