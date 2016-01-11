using UnityEngine;
using System.Collections;

public class TabletAdScene : MonoBehaviour {

	private SampleManager manager = SampleManager.GetInstance();
	private AdInfo adInfo;
	
	void Start () {
		
		adInfo = manager.SelectedAdInfo;
		
		// 初回のみResister(),Start(),Show()を呼び、
		// 2度目以降は、SetVisibility()を使用してください
		if (adInfo.AdViewId == null) {
			IMobileSdkAdsUnityPlugin.registerInline (adInfo.TestPID, adInfo.TestMID, adInfo.TestSID);
			IMobileSdkAdsUnityPlugin.start (adInfo.TestSID);
			adInfo.AdViewId = IMobileSdkAdsUnityPlugin.show (adInfo.TestSID,
			                                                 adInfo.AdType.Value,
			                                                 IMobileSdkAdsUnityPlugin.AdAlignPosition.CENTER,
			                                                 IMobileSdkAdsUnityPlugin.AdValignPosition.MIDDLE);
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
