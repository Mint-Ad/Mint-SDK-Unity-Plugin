using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class SampleManager {

	private static SampleManager instance = new SampleManager();

	public static SampleManager GetInstance() {
		return instance;
	}
	
	public List<AdInfo> SPAds { get; set; }
	public List<AdInfo> TabletAds { get; set; }
	public int SelectedTabIndex { get; set; }
	public AdInfo SelectedAdInfo { get; set; }
	public string HomeSceneName { get { return "SampleTopScene"; } }
	public string TabletAdSceneName { get { return "TabletAdScene"; } }
	
	private SampleManager() {

		// constractor
		this.SPAds = new List<AdInfo>() {
			new AdInfo() {
				AdType = IMobileSdkAdsUnityPlugin.AdType.BANNER,
				SceneName = "BannerScene",
				DisplayName = "バナー",
				AdWidth = 320,
				AdHeight = 50,
				TestPID = "34816",
				TestMID = (Application.platform == RuntimePlatform.IPhonePlayer) ? "135002" : "135179",
				TestSID = (Application.platform == RuntimePlatform.IPhonePlayer) ? "342407" : "342414"
		    },
		    new AdInfo() {
				AdType = IMobileSdkAdsUnityPlugin.AdType.BIG_BANNER,
				SceneName = "BigBannerScene",
				DisplayName = "ビッグバナー",
				AdWidth = 320,
				AdHeight = 100,
				TestPID = "34816",
				TestMID = (Application.platform == RuntimePlatform.IPhonePlayer) ? "135002" : "135179",
				TestSID = (Application.platform == RuntimePlatform.IPhonePlayer) ? "342408" : "342415"
		    },
			new AdInfo() {
				AdType = IMobileSdkAdsUnityPlugin.AdType.MEDIUM_RECTANGLE,
				SceneName = "RectangleScene",
				DisplayName = "レクタングル",
				AdWidth = 300,
				AdHeight = 250,
				TestPID = "34816",
				TestMID = (Application.platform == RuntimePlatform.IPhonePlayer) ? "135002" : "135179",
				TestSID = (Application.platform == RuntimePlatform.IPhonePlayer) ? "342409" : "342416"
			},
			#if UNITY_ANDROID && !UNITY_EDITOR
			new AdInfo() {
				AdType = IMobileSdkAdsUnityPlugin.AdType.ICON,
				SceneName = "IconScene",
				DisplayName = "アイコン",
				AdWidth = 57,
				AdHeight = 57,
				TestPID = "34816",
				TestMID = (Application.platform == RuntimePlatform.IPhonePlayer) ? "135002" : "135179",
				TestSID = (Application.platform == RuntimePlatform.IPhonePlayer) ? "342410" : "342417"
			},
			#endif
			new AdInfo() {
				SceneName = "InterstitialScene",
				DisplayName = "インタースティシャル",
				TestPID = "34816",
				TestMID = (Application.platform == RuntimePlatform.IPhonePlayer) ? "135002" : "135179",
				TestSID = (Application.platform == RuntimePlatform.IPhonePlayer) ? "342411" : "342418"
			},
			#if UNITY_ANDROID && !UNITY_EDITOR
			new AdInfo() {
				SceneName = "WallScene",
				DisplayName = "ウォール",
				TestPID = "34816",
				TestMID = (Application.platform == RuntimePlatform.IPhonePlayer) ? "135002" : "135179",
				TestSID = (Application.platform == RuntimePlatform.IPhonePlayer) ? "349869" : "342419"
			},
			#endif
			new AdInfo() {
				SceneName = "TextPopupScene",
				DisplayName = "テキストポップアップ",
				TestPID = "34816",
				TestMID = (Application.platform == RuntimePlatform.IPhonePlayer) ? "135002" : "135179",
				TestSID = (Application.platform == RuntimePlatform.IPhonePlayer) ? "342412" : "342420"
			},
		};

		this.TabletAds = new List<AdInfo> () {
			#if UNITY_IPHONE && !UNITY_EDITOR
			new AdInfo() {
				AdType = IMobileSdkAdsUnityPlugin.AdType.TABLET_BANNER,
				DisplayName = "タブレットバナー",
				AdWidth = 468,
				AdHeight = 60,
				TestPID = "34816",
				TestMID = "135180",
				TestSID = "342421"
			},
			new AdInfo() {
				AdType = IMobileSdkAdsUnityPlugin.AdType.TABLET_BIG_BANNER,
				DisplayName = "タブレットビッグバナー",
				AdWidth =  768,
				AdHeight = 90,
				TestPID = "34816",
				TestMID = "135180",
				TestSID = "342422"
			},
			new AdInfo() {
				AdType = IMobileSdkAdsUnityPlugin.AdType.SKYSCRAPER,
				DisplayName = "スカイスクレイパー",
				AdWidth =  160,
				AdHeight = 600,
				TestPID = "34816",
				TestMID = "135180",
				TestSID = "342423"
			},
			new AdInfo() {
				AdType = IMobileSdkAdsUnityPlugin.AdType.WIDE_SKYSCRAPER,
				DisplayName = "ワイドスカイスクレイパー",
				AdWidth =  300,
				AdHeight = 600,
				TestPID = "34816",
				TestMID = "135180",
				TestSID = "342424"
			},
			new AdInfo() {
				AdType = IMobileSdkAdsUnityPlugin.AdType.SMALL_SQUARE,
				DisplayName = "スクエア(小)",
				AdWidth =  200,
				AdHeight = 200,
				TestPID = "34816",
				TestMID = "135180",
				TestSID = "342425"
			},
			new AdInfo() {
				AdType = IMobileSdkAdsUnityPlugin.AdType.SQUARE,
				DisplayName = "スクエア",
				AdWidth =  250,
				AdHeight = 250,
				TestPID = "34816",
				TestMID = "135180",
				TestSID = "342426"
			},
			new AdInfo() {
				AdType = IMobileSdkAdsUnityPlugin.AdType.MEDIUM_RECTANGLE,
				DisplayName = "レクタングル",
				AdWidth =  300,
				AdHeight = 250,
				TestPID = "34816",
				TestMID = "135180",
				TestSID = "342427"
			},
			new AdInfo() {
				AdType = IMobileSdkAdsUnityPlugin.AdType.BIG_RECTANGLE,
				DisplayName = "レクタングル(大)",
				AdWidth =  336,
				AdHeight = 280,
				TestPID = "34816",
				TestMID = "135180",
				TestSID = "342428"
			},
			new AdInfo() {
				AdType = IMobileSdkAdsUnityPlugin.AdType.HALFPAGE,
				DisplayName = "ハーフページ",
				AdWidth =  300,
				AdHeight = 600,
				TestPID = "34816",
				TestMID = "135180",
				TestSID = "342429"
			},
			#endif
		};

		// デフォルト値を設定
		this.SelectedTabIndex = 0;

		// ScreenScaleの計算
		this.screenScale = (float)(Screen.height / DefaultScreenHeight);

		// 各定数の計算
		this.logoTopMargin = (int)(80 * this.screenScale);
		this.listTopMargin = (int)(200 * this.screenScale);
		this.buttonBottomMargin = (int)(40 * this.screenScale);
		this.listButtonWidth = (int)(560 * this.screenScale);
		this.listButtonHeight = (int)(80 * this.screenScale);
		this.commonButtonWidth = (int)(224 * this.screenScale);
		this.commonButtonHeight = (int)(72 * this.screenScale);
		this.fontSize = (int)(28 * this.screenScale);
		this.imobileLogoWidth = (int)(248 * this.screenScale);
		this.unityLogoWidth = (int)(136 * this.screenScale);
		this.logoHeight = (int)(50 * this.screenScale);
	}

	// Const
	private const float DefaultScreenWidth = 640;
	private const float DefaultScreenHeight = 1136;

	// ScreenScale
	private float screenScale;

	// 各マージン
	private int logoTopMargin;
	private int listTopMargin;
	private int buttonBottomMargin;

	// 各ボタンサイズ
	private int listButtonWidth;
	private int listButtonHeight;
	private int commonButtonWidth;
	private int commonButtonHeight;

	// フォントサイズ
	private int fontSize;

	// GUIStyle & Texture
	private GUIStyle loadAdSceneButtonStyle;
	private GUIStyle commonButtonStyle;
	private Texture2D imobileLogo;
	private Texture2D unityLogo;
	private int imobileLogoWidth;
	private int unityLogoWidth;
	private int logoHeight;

	public void AddImobileLogo() {
		if (this.imobileLogo == null) {
			var texture = new Texture2D(this.imobileLogoWidth, this.logoHeight);
			var image = Resources.Load("imobileLogo") as TextAsset;
			texture.LoadImage(image.bytes);
			this.imobileLogo = texture;
		}
		var left = (Screen.width - listButtonWidth) / 2;
		GUI.Label (new Rect (left, logoTopMargin, this.imobileLogoWidth, this.logoHeight), this.imobileLogo);
	}

	public void AddUnityLogo() {
		if (this.unityLogo == null) {
			var texture = new Texture2D(this.unityLogoWidth, this.logoHeight);
			var image = Resources.Load("unityLogo") as TextAsset;
			texture.LoadImage(image.bytes);
			this.unityLogo = texture;
		}
		var left = (Screen.width - listButtonWidth) / 2 + listButtonWidth -  this.unityLogoWidth;
		GUI.Label (new Rect (left, logoTopMargin, this.unityLogoWidth, this.logoHeight), this.unityLogo);
	}

	public bool AddLoadAdSceneButton(int buttonIndex, string buttonTitle) {

		// Initialize Style, Why not in Constractor? -> because of timing.
		// Error mMessage: Constructors of C# classes may not load objects either eg. EditorGUIUtility.TextContent should be moved to OnEnable. See stacktrace.
		if (this.loadAdSceneButtonStyle == null) {
			this.loadAdSceneButtonStyle = this.GetLoadAdSceneButtonStyle();
		}

		var content = new GUIContent ();
		content.text = buttonTitle;

		int top = listTopMargin + listButtonHeight * buttonIndex;
		int left = (Screen.width - listButtonWidth) / 2;
		return GUI.Button (new Rect (left, top, listButtonWidth, listButtonHeight), content, this.loadAdSceneButtonStyle);
	}
	
	public bool AddBackButton() {

		// Initialize Style, Why not in Constractor? -> because of timing.
		// Error mMessage: Constructors of C# classes may not load objects either eg. EditorGUIUtility.TextContent should be moved to OnEnable. See stacktrace.
		if (this.commonButtonStyle == null) {
			this.commonButtonStyle = this.GetCommonButtonStyle();
		}

		var content = new GUIContent ();
		content.text = "戻る";

		int top = Screen.height - commonButtonHeight - buttonBottomMargin;
		int left = (Screen.width - commonButtonWidth) / 2;
		return GUI.Button (new Rect (left, top, commonButtonWidth, commonButtonHeight), content, this.commonButtonStyle);
	}

	public bool AdAdShowButton(string buttonTitle) {

		// Initialize Style, Why not in Constractor? -> because of timing.
		// Error mMessage: Constructors of C# classes may not load objects either eg. EditorGUIUtility.TextContent should be moved to OnEnable. See stacktrace.
		if (this.commonButtonStyle == null) {
			this.commonButtonStyle = this.GetCommonButtonStyle();
		}

		int top = (Screen.height - listButtonHeight) / 2;
		int left = (Screen.width - listButtonWidth) / 2;

		return GUI.Button (new Rect (left, top, listButtonWidth, listButtonHeight), buttonTitle, this.commonButtonStyle);
	}

	public void AdTypeSelectTab() {

		// Initialize Style, Why not in Constractor? -> because of timing.
		// Error mMessage: Constructors of C# classes may not load objects either eg. EditorGUIUtility.TextContent should be moved to OnEnable. See stacktrace.
		if (this.commonButtonStyle == null) {
			this.commonButtonStyle = this.GetCommonButtonStyle();
		}

		var contents = new GUIContent[2];
		contents [0] = new GUIContent ();
		contents [0].text = "SP広告";
		contents [1] = new GUIContent ();
		contents [1].text = "タブレット広告";

		int top = Screen.height - commonButtonHeight - buttonBottomMargin;
		int left = (Screen.width - commonButtonWidth * 2) / 2;
		
		this.SelectedTabIndex = GUI.Toolbar (new Rect (left, top, commonButtonWidth * 2, commonButtonHeight),
		             						 this.SelectedTabIndex, 
		                                     contents, this.commonButtonStyle);
	}

	private GUIStyle GetLoadAdSceneButtonStyle() {

		var normalTexture = new Texture2D(560, 80);
		var normalImage = Resources.Load("ListButton") as TextAsset;
		normalTexture.LoadImage(normalImage.bytes);
		
		var activeTexture = new Texture2D(560, 80);
		var activeImage = Resources.Load("ListButtonActived") as TextAsset;
		activeTexture.LoadImage(activeImage.bytes);
		
		var style = new GUIStyle(GUI.skin.button);
		style.fontSize = this.fontSize;
		style.alignment = TextAnchor.MiddleLeft;
		style.padding = new RectOffset (32, 32, 8, 0);
		style.normal.background = normalTexture;
		style.normal.textColor = new Color(0.1f, 0.1f, 0.1f);
		style.active.background = activeTexture;
		style.active.textColor = new Color(0.1f, 0.1f, 0.1f); 
		return style;
	}

	private GUIStyle GetCommonButtonStyle() {
	
		var normalTexture = new Texture2D(192, 72);
		var normalImage = Resources.Load("CommonButton") as TextAsset;
		normalTexture.LoadImage(normalImage.bytes);
		
		var activeTexture = new Texture2D(192, 72);
		var activeImage = Resources.Load("CommonButtonActived") as TextAsset;
		activeTexture.LoadImage(activeImage.bytes);

		var selectedTexture = new Texture2D(192, 72);
		var selectedImage = Resources.Load("CommonButtonSelected") as TextAsset;
		selectedTexture.LoadImage(selectedImage.bytes);

		var style = new GUIStyle(GUI.skin.button);
		style.fontSize = this.fontSize;
		style.alignment = TextAnchor.MiddleCenter;
		style.padding = new RectOffset (2, 2, 4, 0);
		style.normal.background = normalTexture;
		style.normal.textColor = new Color(0.1f, 0.1f, 0.1f);
		style.active.background = activeTexture;
		style.active.textColor = new Color(0.1f, 0.1f, 0.1f); 
		style.onNormal.background = selectedTexture;
		style.onNormal.textColor = new Color(1.0f, 1.0f, 1.0f);
		style.onActive.background = activeTexture;
		style.onActive.textColor = new Color(0.1f, 0.1f, 0.1f);
		return style;
	}
}

public class AdInfo {

	public IMobileSdkAdsUnityPlugin.AdType? AdType { get; set; }
	public string DisplayName { get; set; }
	public string SceneName { get; set; }
	public int? AdWidth { get; set; }
	public int? AdHeight { get; set; }
	public string TestPID { get; set; }
	public string TestMID { get; set; }
	public string TestSID { get; set; }
	public int? AdViewId { get; set; }
}
