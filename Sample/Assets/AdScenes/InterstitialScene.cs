using UnityEngine;
using System.Collections;

public class InterstitialScene : MonoBehaviour {

	private SampleManager manager = SampleManager.GetInstance();
	private AdInfo adInfo;
	
	void Start () {
		
		adInfo = manager.SPAds.Find (ad => ad.SceneName == "InterstitialScene");
		
		// 初回のみResister(),Start()を呼びます。
		// 2度目以降と区別するため、AdViewIdに0を設定します
		if (adInfo.AdViewId == null) {
			IMobileSdkAdsUnityPlugin.registerFullScreen (adInfo.TestPID, adInfo.TestMID, adInfo.TestSID);
			IMobileSdkAdsUnityPlugin.start (adInfo.TestSID);
			adInfo.AdViewId = 0;
		}
	}
	
	void OnGUI () {

		if (manager.AdAdShowButton (adInfo.DisplayName + "広告を表示します")) {

			// Show()を呼び、広告を表示します
			IMobileSdkAdsUnityPlugin.show (adInfo.TestSID);
		}

		if (manager.AddBackButton ()) {

			// TopSceneに戻ります
			Application.LoadLevel(manager.HomeSceneName);
		}
	}
}
