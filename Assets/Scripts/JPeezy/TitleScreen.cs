using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TitleScreen : MonoBehaviour {

	int menuState;
	public int numPages = 6;
	public Navigation nextNav1;
	public Navigation nextNav2;
	public Navigation titleNav1;
	public Navigation titleNav2;
	public Navigation prevNav1;
	public Navigation prevNav2;
	// Use this for initialization
	void Start () {
		menuState = 0;
		nextNav1 = new Navigation(); // SelectOnLeft = Back to Title
		nextNav1.mode = Navigation.Mode.Explicit;
		nextNav1.selectOnLeft = transform.GetChild(transform.GetChildCount()-1).GetComponent<Selectable>();
		nextNav2 = new Navigation(); // SelectOnLeft = Prev
		nextNav2.mode = Navigation.Mode.Explicit;
		nextNav2.selectOnLeft = transform.GetChild(transform.GetChildCount()-3).GetComponent<Selectable>();	
		titleNav1 = new Navigation(); // SelectOnRight = Next
		titleNav1.mode = Navigation.Mode.Explicit;
		titleNav1.selectOnRight = transform.GetChild(transform.GetChildCount()-2).GetComponent<Selectable>();
		titleNav2 = new Navigation(); // SelectOnRight = Prev
		titleNav2.mode = Navigation.Mode.Explicit;
		titleNav2.selectOnRight = transform.GetChild(transform.GetChildCount()-3).GetComponent<Selectable>();
		prevNav1 = new Navigation(); // SelectOnRight = Next
		prevNav1.mode = Navigation.Mode.Explicit;
		prevNav1.selectOnLeft = transform.GetChild(transform.GetChildCount()-1).GetComponent<Selectable>();
		prevNav1.selectOnRight = transform.GetChild(transform.GetChildCount()-2).GetComponent<Selectable>();
		prevNav2 = new Navigation(); // SelectOnLeft = null
		prevNav2.mode = Navigation.Mode.Explicit;
		prevNav2.selectOnLeft = transform.GetChild(transform.GetChildCount()-1).GetComponent<Selectable>();
		prevNav2.selectOnRight = null;
	}
	

	void Update()
	{
		Debug.Log(transform.GetChild(transform.GetChildCount()-1).GetComponent<Selectable>().navigation.selectOnRight);
		Debug.Log(transform.GetChild(transform.GetChildCount()-2).GetComponent<Selectable>().navigation.selectOnLeft);
	}

	public void PlayLevel()
	{
		Application.LoadLevel("Final_v2");
	}

	public void QuitGame()
	{
		Application.Quit();
	}

	public void GoToTut()
	{
		UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(null);
		for (int i = 0;i<4;i++)
		{
			transform.GetChild(i).gameObject.SetActive(false);
		}
		ShowTut(1);
		UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(transform.GetChild(transform.GetChildCount()-1).gameObject);
	}

	void ShowTut(int tutNum)
	{
		menuState = tutNum;
		for (int i = 4;i<10;i++)
		{
			transform.GetChild(i).gameObject.SetActive(false);
		}
		transform.GetChild(3+tutNum).gameObject.SetActive(true);
		transform.GetChild(transform.GetChildCount()-1).gameObject.SetActive(true);
		transform.GetChild(transform.GetChildCount()-3).gameObject.SetActive(true);
		transform.GetChild(transform.GetChildCount()-2).gameObject.SetActive(true);
		transform.GetChild(transform.GetChildCount()-1).GetComponent<Selectable>().interactable = true;
		transform.GetChild(transform.GetChildCount()-2).GetComponent<Selectable>().interactable = true;
		transform.GetChild(transform.GetChildCount()-3).GetComponent<Selectable>().interactable = true;
		if (tutNum == 1)//hide Prev
		{
			transform.GetChild(transform.GetChildCount()-3).GetComponent<Selectable>().interactable = false;
			transform.GetChild(transform.GetChildCount()-1).GetComponent<Selectable>().navigation = titleNav1;
			transform.GetChild(transform.GetChildCount()-2).GetComponent<Selectable>().navigation = nextNav1;
			transform.GetChild(transform.GetChildCount()-3).GetComponent<Selectable>().navigation = prevNav1;
			//Adjust Selection - select next
			if (UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject == transform.GetChild(transform.GetChildCount()-3).gameObject)
			{
				UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(transform.GetChild(transform.GetChildCount()-2).gameObject);
			}
		}
		else if (tutNum == 6) // hide Next
		{
			transform.GetChild(transform.GetChildCount()-2).GetComponent<Selectable>().interactable = false;
			transform.GetChild(transform.GetChildCount()-1).GetComponent<Selectable>().navigation = titleNav2;
			transform.GetChild(transform.GetChildCount()-2).GetComponent<Selectable>().navigation = nextNav2;
			transform.GetChild(transform.GetChildCount()-3).GetComponent<Selectable>().navigation = prevNav2;
			//Adjust Selection - select Prev
			if (UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject == transform.GetChild(transform.GetChildCount()-2).gameObject)
			{
				UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(transform.GetChild(transform.GetChildCount()-3).gameObject);
			}
		}
		else // Both Visible
		{
			transform.GetChild(transform.GetChildCount()-1).GetComponent<Selectable>().navigation = titleNav2;
			transform.GetChild(transform.GetChildCount()-2).GetComponent<Selectable>().navigation = nextNav2;
			transform.GetChild(transform.GetChildCount()-3).GetComponent<Selectable>().navigation = prevNav1;
		}

	}

	public void GoToTitle()
	{
		UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(null);
		for (int i = 0;i<4;i++)
		{
			transform.GetChild(i).gameObject.SetActive(true);
		}
		for (int i = 4;i<transform.GetChildCount();i++)
		{
			transform.GetChild(i).gameObject.SetActive(false);
		}
		UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(transform.GetChild(1).gameObject);
	}

	public void NextPage()
	{
		if (menuState < numPages)
		{
			ShowTut(menuState+1);
		}
	}

	public void PrevPage()
	{
		if (menuState > 1)
		{
			ShowTut(menuState-1);
		}
	}
}
