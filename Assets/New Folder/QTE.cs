using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class QuickTimeEvent : MonoBehaviour
{
    public GameObject targetObject;
    public GameObject g;

    public AudioSource audioSource;
    public AudioClip soundEffect;

    [Header("UI References")]
    public GameObject qteCanvas;
    public TextMeshProUGUI promptText;
    public Slider timerSlider;

    [Header("Settings")]
    public float timeLimit = 2.0f;
    private float currentTime;
    private bool isQTEActive = false;
    private KeyCode requiredKey;

    void Start()
    {
        targetObject.SetActive(false);

        if (qteCanvas != null)
            qteCanvas.SetActive(false);
        g.SetActive(false);
    }

    void Update()
    {
        if (!isQTEActive) return;

        currentTime -= Time.deltaTime;
        if (timerSlider != null)
        {
            timerSlider.value = currentTime / timeLimit;
        }

        if (Input.GetKeyDown(requiredKey))
        {
            Success();
        }
        else if (currentTime <= 0f)
        {
            Failure();
        }
    }

    public void TriggerQTE(KeyCode keyToPress, float duration)
    {
        requiredKey = keyToPress;
        timeLimit = duration;
        currentTime = timeLimit;
        isQTEActive = true;

        if (promptText != null)
            promptText.text = "Press [" + keyToPress.ToString().ToUpper() + "]!";

        if (qteCanvas != null)
            qteCanvas.SetActive(true);
            StartCoroutine(FadeIn());
    }

    void Success()
    {
        isQTEActive = false;
        if (qteCanvas != null)
            qteCanvas.SetActive(false);
        meh.count++;
        Debug.Log("QTE Success!");
        audioSource.PlayOneShot(soundEffect);
        if (meh.count == 2)
        {
        Application.Quit();
        }

    }
    IEnumerator FadeIn()
    {
        yield return new WaitForSeconds(5f);
    }
        void Failure()
    {
        isQTEActive = false;
        if (qteCanvas != null)
            qteCanvas.SetActive(false);
        
        Debug.Log("QTE Failed!");
        targetObject.SetActive(true);
        g.SetActive(true);


    }
}