using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SampleTopScene : MonoBehaviour {

	private SampleManager manager = SampleManager.GetInstance();

	// Use this for initialization
	void Start () {

		// SetScreenOrientation
		Screen.autorotateToPortrait = true;
		Screen.autorotateToLandscapeLeft = false;
		Screen.autorotateToLandscapeRight = false;
		Screen.autorotateToPortraitUpsideDown = false;

		IMobileSdkAdsUnityPlugin.setTestMode (true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// OnGUI
	void OnGUI() {

		// Show i-mobile & Unity logo
		manager.AddImobileLogo ();
		manager.AddUnityLogo ();

		// Create Ad Buttons
		// TODO: Refactor index. Not cool at all.
		var index = 0;
		if (manager.SelectedTabIndex == 0) {
			manager.SPAds.ForEach (ad => {
				string buttonSizeStr;
				if (ad.AdWidth.HasValue) {
					buttonSizeStr =  "(" + ad.AdWidth + " x " + ad.AdHeight + ")"; 
				} else {
					buttonSizeStr = "(全画面)";	
				}
				var buttonTitle = ad.DisplayName + " " + buttonSizeStr;
				if (manager.AddLoadAdSceneButton(index, buttonTitle)) {
					if (!ad.AdWidth.HasValue) {
						// SetScreenOrientation
						Screen.autorotateToPortrait = true;
						Screen.autorotateToLandscapeLeft = true;
						Screen.autorotateToLandscapeRight = true;
						Screen.autorotateToPortraitUpsideDown = true;
					}
					Application.LoadLevel (ad.SceneName);
				}
				index++;
			});
		} else {
			manager.TabletAds.ForEach (ad => {

				var buttonSizeStr =  "(" + ad.AdWidth + " x " + ad.AdHeight + ")"; 
				var buttonTitle = ad.DisplayName + " " + buttonSizeStr;
				if (manager.AddLoadAdSceneButton(index, buttonTitle)) {
					manager.SelectedAdInfo = ad;
					Application.LoadLevel (manager.TabletAdSceneName);
				}
				index++;
			});
		}

		// Create a Tab to switch SP <=> Tablet
		manager.AdTypeSelectTab ();
	}
}
