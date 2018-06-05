using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupFaderState : MonoBehaviour {

    public CanvasGroup uiElement;

	bool _panelActive;

	private void Start()
	{
        uiElement.alpha = 0;
        _panelActive = false;
	}

    
	public void ChangeState()
	{
		if (_panelActive == false)
		{
			StartCoroutine(FadeCanvasGroup(uiElement, uiElement.alpha, 1));
			_panelActive = true;
			print("fade in");
		}
		else if (_panelActive == true)
		{
			StartCoroutine(FadeCanvasGroup(uiElement, uiElement.alpha, 0));
			_panelActive = false;
			print("fade out");
		}
		else Start();   
		
	}

    public IEnumerator FadeCanvasGroup(CanvasGroup canvasGroup, float start, float end, float lerpTime = 0.5f)
    {
        float _timeStartedLerp = Time.time;
        float timeSinceStarted = Time.time - _timeStartedLerp;
        float percentageComplete = timeSinceStarted / lerpTime;

        while(true)
        {
            timeSinceStarted = Time.time - _timeStartedLerp;
            percentageComplete = timeSinceStarted / lerpTime;

            float currentValue = Mathf.Lerp(start, end, percentageComplete);

            canvasGroup.alpha = currentValue;

            if (percentageComplete >= 1) break;

            yield return new WaitForEndOfFrame();
        }

        print("done");
    }
}
