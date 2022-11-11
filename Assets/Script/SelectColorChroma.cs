using UnityEngine;
using UnityEngine.UI;

public class SelectColorChroma : MonoBehaviour
{
	public Material colorChroma;
	public ColorPicker picker;


	void Start()
	{

		picker.onValueChanged.AddListener(color =>
		{
			//picker.CurrentColor = Color.green;
			colorChroma.SetColor("_KeyColor", picker.CurrentColor);
			
		});



	}
}
