using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Assets.script.SplashScreen {
   
	public class FadeInOut : MonoBehaviour
	{
        public Image black;
        public float speed = -0.02f;
        private Color _blackColor = Color.black;

        void Awake()
		{
            FadeIn();
		}
		
		void Update()
        {
            _blackColor.a += speed;
            _blackColor.a = Mathf.Clamp01(_blackColor.a);
            black.color = _blackColor;
		}
		
		// 淡入淡出
		private void FadeIn()
		{
            _blackColor.a = 1;
			speed = - Mathf.Abs(speed);
		}
		
        private void FadeOut()
		{
            _blackColor.a = 0;
			speed = Mathf.Abs(speed);
		}

        IEnumerator LoadFor(int map) 
        {
            yield return new WaitForSeconds(0.9f);
            SceneManager.LoadScene(map);
        }

        IEnumerator LoadFor(string map)
        {
            yield return new WaitForSeconds(0.9f);
            SceneManager.LoadScene(map);
        }
		
		// 淡化+轉場
        public void FadeAndGo(string map)
		{
			FadeOut();
            StartCoroutine(LoadFor(map));

		}
		
        public void FadeAndGo(int map)
		{
			FadeOut();
            StartCoroutine(LoadFor(map));
		}
		
	}
	
}