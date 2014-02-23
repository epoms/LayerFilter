using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class LayerFilter : EditorWindow
{
	Color black = Color.black;
	Color white = Color.white;

	List<string> layers = new List<string>();
	List<Color> colors = new List<Color>();

	[MenuItem("Window/LayerFilter")]
	static void Init () 
	{
		LayerFilter window = (LayerFilter)EditorWindow.GetWindow (typeof (LayerFilter));
	}

	void Awake()
	{

		for( int i = 0; i < 32; ++i )
		{
			string layerName = LayerMask.LayerToName(i);

			layers.Add(layerName);
			colors.Add(Color.white);
		}

		for( int i = 0; i < 32; i++)
		{
			Color color = new Color(
								EditorPrefs.GetFloat(i + "r", 1.0f),
		                        EditorPrefs.GetFloat(i + "g", 1.0f),
		                        EditorPrefs.GetFloat(i + "b", 1.0f),
		                        EditorPrefs.GetFloat(i + "a", 1.0f));
			colors[i] = color;
		}
	}
	
	void OnDestroy()
	{
		for( int i = 0; i < 32; i++)
		{
			Color myColor = colors[i];
			EditorPrefs.SetFloat(i + "r", myColor.r);
			EditorPrefs.SetFloat(i + "g", myColor.g);
			EditorPrefs.SetFloat(i + "b", myColor.b);
			EditorPrefs.SetFloat(i + "a", myColor.a);
		}
	}

	void OnGUI()
	{

		for(int i = 0; i < colors.Count; i++)
		{
			if(layers[i].Length > 0)
				colors[i] = EditorGUILayout.ColorField (layers[i], colors[i]);
		}

		if(GUILayout.Button("Apply"))
		{
			Object[] objects = GameObject.FindObjectsOfType(typeof (GameObject));
			foreach(Object o in objects)
			{
				GameObject g = (GameObject) o;
				if (g != null)
				{

					SpriteRenderer sp = (SpriteRenderer) g.GetComponent(typeof(SpriteRenderer));
					if(sp)
					{
						Debug.Log(g);
						Debug.Log (g.layer);
						Debug.Log(colors[g.layer]);
						sp.color = colors[g.layer];
					}
				}
			}
		}

		if(GUILayout.Button("Clear"))
		{
			Object[] objects = GameObject.FindObjectsOfType(typeof (GameObject));
			foreach(Object o in objects)
			{
				GameObject g = (GameObject) o;
				if (g != null)
				{
					SpriteRenderer sp = (SpriteRenderer) g.GetComponent(typeof(SpriteRenderer));
					if(sp)
					{
						sp.color = Color.white;
					}
				}
			}
		}
	}
}