using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace VHS
{
    public class InteractionUIPanel : MonoBehaviour
    {
        [SerializeField] private Image progressBar;
        [SerializeField] private TextMeshProUGUI tooltipText;
        [SerializeField] private TextMeshProUGUI othertext;
        [SerializeField] private TextMeshProUGUI upText;
        [SerializeField] private TextMeshProUGUI leftText;
        [SerializeField] private TextMeshProUGUI rightText;
        [SerializeField] private TextMeshProUGUI Point1Tracker;
        [SerializeField] private float TextFade = 1f;
        TextMeshProUGUI m_textLocation;
        float points1 = 0f;
        private bool tempmessage = false;
        public GameObject agent;



        public void SetTooltip(string tooltip)
        {
            if (!tempmessage)
            {
                tooltipText.SetText(tooltip);
            }
            
        }

        public IEnumerator FadeTextToZeroAlpha(float t, Text i)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
            while (i.color.a > 0.0f)
            {
                i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
                yield return null;
            }
        }
        public void TempMessage(string text, string type = "neutral")
        {

            othertext.SetText(text);

            if (type == "neutral")
            {
                othertext.color = new Color(0, 0, 0, 1);
            }

            if (type == "warning")
            {
                othertext.color = new Color(250, 0, 0, 1);
            }

            if (type == "green")
            {
                othertext.color = new Color(0, 128, 0, 1);
            }

            othertext.CrossFadeAlpha(1, 0, false);
            
            othertext.CrossFadeAlpha(0, TextFade, false);
        }
        public void RandomText3(string text1, string text2, string text3)
        {
            float n1 = Random.Range(1, 4);

            float n2 = Random.Range(1, 4);

            //Debug.Log(n1);


            if (n2 == 1)
            {
                 m_textLocation = upText;
            }

            if (n2 == 2)
            {
                m_textLocation = leftText;
            }

            if (n2 == 3)
            {
                m_textLocation = rightText;
            }

            if (n1 == 1)
	        {
                m_textLocation.SetText(text1);
                m_textLocation.CrossFadeAlpha(1, 0, false);
                m_textLocation.CrossFadeAlpha(0, TextFade, false);

	        }

            if (n1 == 2)
            {
                m_textLocation.SetText(text2);
                m_textLocation.CrossFadeAlpha(1, 0, false);
                m_textLocation.CrossFadeAlpha(0, TextFade, false);
            }

            if (n1 == 3)
            {
                m_textLocation.SetText(text3);
                m_textLocation.CrossFadeAlpha(1, 0, false);
                m_textLocation.CrossFadeAlpha(0, TextFade, false);
            }
        }

        public void UpdateProgressBar(float fillAmount)
        {
            progressBar.fillAmount = fillAmount;
        }

        public void Point1Update(float pointchange)
        {
            points1 += pointchange;
            Point1Tracker.SetText("Points1 = " + points1);

            //also write to data file
            bool testfile = agent.GetComponent<ColliderScript>().testfile; //get testfile from ColliderScript
            ColliderScript.updateData("Gained points in " + agent.GetComponent<ColliderScript>().location, pointchange, testfile); 
        }

        public void ResetUI()
        {
            progressBar.fillAmount = 0f;
            tooltipText.SetText("");
        }
    }
}