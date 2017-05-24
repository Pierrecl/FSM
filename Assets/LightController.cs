using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;

public class LightController : MonoBehaviour {

	KeywordRecognizer keywordRecognizer;
	Dictionary<string,System.Action> keywords = new Dictionary<string,System.Action>();

	// Use this for initialization
	void Start () {
		keywords.Add("go",() =>
			{
				goCalled();
			});

		keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());
		keywordRecognizer.OnPhraseRecognized += KeywordRecognizerOnPhraseRecognized;
		keywordRecognizer.Start();
	}

	void KeywordRecognizerOnPhraseRecognized(PhraseRecognizedEventArgs args)
	{
		System.Action keyWordAction;
		if (keywords.TryGetValue(args.text, out keyWordAction)) {
			keyWordAction.Invoke();
		}
	}
	// Update is called once per frame
	void Update () {
		
	}

	void goCalled()
	{
		print("You just said GO");
	}
}
