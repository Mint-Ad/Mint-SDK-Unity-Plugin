using UnityEngine;
using System.Collections;

public class IconScene : MonoBehaviour {

	private SampleManager manager = SampleManager.GetInstance();
	private AdInfo adInfo;
	
	void Start () {
		
		adInfo = manager.SPAds.Find (ad => ad.SceneName == "IconScene");
		
		// 初回のみResister(),Start(),Show()を呼び、
		// 2度目以降は、SetVisibility()を使用してください
		if (adInfo.AdViewId == null) {
			IMobileSdkAdsUnityPlugin.registerInline (adInfo.TestPID, adInfo.TestMID, adInfo.TestSID);
			IMobileSdkAdsUnityPlugin.start (adInfo.TestSID);
			var iconParam = new IMobileIconParams();
			iconParam.iconNumber = 5;
			iconParam.iconSize = 52;
			iconParam.iconTitleEnable = false;
			adInfo.AdViewId = IMobileSdkAdsUnityPlugin.show (adInfo.TestSID,
			                                                 IMobileSdkAdsUnityPlugin.AdType.ICON,
			                                                 IMobileSdkAdsUnityPlugin.AdAlignPosition.CENTER,
			                                                 IMobileSdkAdsUnityPlugin.AdValignPosition.MIDDLE,
			                                                 iconParam);
		} else {
			IMobileSdkAdsUnityPlugin.setVisibility(adInfo.AdViewId.Value, true);
		}
	}
	
	void OnGUI () {
		
		// TopSceneに戻る前に、SetVisibility()を使用して広告を非表示にします
		if (manager.AddBackButton ()) {
			IMobileSdkAdsUnityPlugin.setVisibility(adInfo.AdViewId.Value, false);
			Application.LoadLevel(manager.HomeSceneName);
		}
	}
}
