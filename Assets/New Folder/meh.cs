using UnityEngine;
using System.Collections;

public class meh : MonoBehaviour
{
    static public int count = 0;
    void Start()
    {
        StartCoroutine(FadeOut());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator FadeOut()
    {

        yield return new WaitForSeconds(15f);
        FindObjectOfType<QuickTimeEvent>().TriggerQTE(KeyCode.E, 2.5f);
        if (count == 1)
            yield return new WaitForSeconds(10f);
            FindObjectOfType<QuickTimeEvent>().TriggerQTE(KeyCode.R, 2.5f);
        if (count == 2)
            yield return new WaitForSeconds(5f);
            FindObjectOfType<QuickTimeEvent>().TriggerQTE(KeyCode.F, 1.5f);
    }
}
