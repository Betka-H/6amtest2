using UnityEngine;
using UnityEngine.EventSystems;

public class objectHighlight : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
	private SpriteRenderer spriteRenderer;
	private Color defaultColor;
	Color hoverColor = HexToColor("#d0d0d0"); // E7E7E7
	Color activeColor = HexToColor("#a0a0a0"); // DBDBDB

	void Awake()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
		defaultColor = spriteRenderer.color; // note down the default color
	}

	private bool isActive; // prevents the hover color staying while clicking and moving the mouse outside the object
	public void OnPointerEnter(PointerEventData eventData)
	{
		isActive = true;
		setColor(hoverColor);
	}
	public void OnPointerExit(PointerEventData eventData)
	{
		isActive = false;
		setColor(defaultColor);
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		setColor(activeColor);
	}
	public void OnPointerUp(PointerEventData eventData)
	{
		if (isActive) // prevents the hover color staying while clicking and moving the mouse outside the object
		{
			setColor(hoverColor);
		}
	}

	void OnDisable()
	{
		OnPointerExit(null); // prevents the hover color from staying after being disabled
	}

	static Color HexToColor(string hex)
	{
		Color color;
		ColorUtility.TryParseHtmlString(hex, out color);
		return color;
	}
	void setColor(Color color) // default, hover, active
	{
		spriteRenderer.color = color;
	}
}



/* 

using UnityEngine;
using UnityEngine.EventSystems;

public class objectHighlight : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
	private SpriteRenderer spriteRenderer;
	private Color defaultColor;
	Color hoverColor = HexToColor("#d0d0d0"); // E7E7E7
	Color activeColor = HexToColor("#a0a0a0"); // DBDBDB

	void Awake()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
		defaultColor = spriteRenderer.color; // note down the default color
	}

	private bool isActive; // prevents the hover color staying while clicking and moving the mouse outside the object
	public void OnPointerEnter(PointerEventData eventData)
	{
		isActive = true;
		setColor(hoverColor);
	}
	public void OnPointerExit(PointerEventData eventData)
	{
		isActive = false;
		setColor(defaultColor);
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		setColor(activeColor);
	}
	public void OnPointerUp(PointerEventData eventData)
	{
		if (isActive) // prevents the hover color staying while clicking and moving the mouse outside the object
		{
			setColor(hoverColor);
		}
	}

	void OnDisable()
	{
		OnPointerExit(null); // prevents the hover color from staying after being disabled
	}

	static Color HexToColor(string hex)
	{
		Color color;
		ColorUtility.TryParseHtmlString(hex, out color);
		return color;
	}
	void setColor(Color color) // default, hover, active
	{
		spriteRenderer.color = color;
	}
}

 */




/* 

using UnityEngine;

public class objectHighlight : MonoBehaviour
{
	SpriteRenderer spriteRenderer;
	Color defaultColor;
	Color hoverColor = HexToColor("#d0d0d0"); // E7E7E7
	Color activeColor = HexToColor("#a0a0a0"); // DBDBDB

	void Awake()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
		defaultColor = spriteRenderer.color; // note down the default color
	}

	bool isActive; // prevents the hover color staying while clicking and moving the mouse outside the object
	void OnMouseEnter()
	{
		isActive = true;
		setColor(hoverColor);
	}
	void OnMouseExit()
	{
		isActive = false;
		setColor(defaultColor);
	}
	void OnMouseDown()
	{
		setColor(activeColor);
	}
	void OnMouseUp()
	{
		if (isActive) // prevents the hover color staying while clicking and moving the mouse outside the object
		{
			setColor(hoverColor);
		}
	}

	void OnDisable()
	{
		OnMouseExit(); // prevents the hover color from staying after being disabled
	}

	static Color HexToColor(string hex)
	{
		Color color;
		ColorUtility.TryParseHtmlString(hex, out color);
		return color;
	}
	void setColor(Color color)
	{
		GetComponent<SpriteRenderer>().color = color;
	}
}

 */