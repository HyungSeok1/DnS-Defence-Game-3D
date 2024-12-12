using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Start_scene : MonoBehaviour
{
    public GameObject panel;
    public bool isFaded = false;

    void Start()
    {
        isFaded = false;
        panel.GetComponent<CanvasRenderer>().SetAlpha(0);
    }
    void Update()
    {
        if (isFaded == true)
        {
            SceneManager.LoadScene("Game");
        }
    }

    IEnumerator CoFadeIn()
    {
        float elapsedTime = 0f; // 누적 경과 시간
        float fadedTime = 0.5f; // 총 소요 시간

        while (elapsedTime <= fadedTime)
        {
            panel.GetComponent<CanvasRenderer>().SetAlpha(Mathf.Lerp(0f, 1f, elapsedTime / fadedTime));
            
            elapsedTime += Time.deltaTime;
            Debug.Log("Fade In 중...");
            yield return null;
        }
        Debug.Log("Fade In 끝");
        isFaded = true;
        yield break;
    }

    //버튼을 누르면 scene 전환
    public void OnClickStart()
    {
        StartCoroutine(CoFadeIn());
    }
}
