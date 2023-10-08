using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : LivingEntity
{
	public GameObject Hearts;
	private void Update()
	{
		Heart();
	}
    private void Heart()
	{
		if (startHealth == 4f)
		{	
			Debug.Log("startHealth:" + startHealth);
			if (Health == 4f)
			{
				Hearts.transform.Find("Heart3").Find("HF").gameObject.SetActive(true);
				Hearts.transform.Find("Heart3").Find("HM").gameObject.SetActive(true);
				Hearts.transform.Find("Heart3").Find("HN").gameObject.SetActive(true);
				Hearts.transform.Find("Heart2").Find("HF").gameObject.SetActive(true);
				Hearts.transform.Find("Heart2").Find("HM").gameObject.SetActive(true);
				Hearts.transform.Find("Heart2").Find("HN").gameObject.SetActive(true);
				Hearts.transform.Find("Heart1").Find("HF").gameObject.SetActive(true);
				Hearts.transform.Find("Heart1").Find("HM").gameObject.SetActive(true);
				Hearts.transform.Find("Heart1").Find("HN").gameObject.SetActive(true);
				Hearts.transform.Find("Heart0").Find("HF").gameObject.SetActive(true);
				Hearts.transform.Find("Heart0").Find("HM").gameObject.SetActive(true);
				Hearts.transform.Find("Heart0").Find("HN").gameObject.SetActive(true);
			}

			if (Health == 3.5f)
			{
				Hearts.transform.Find("Heart3").Find("HF").gameObject.SetActive(false);
				Hearts.transform.Find("Heart3").Find("HM").gameObject.SetActive(true);
				Hearts.transform.Find("Heart3").Find("HN").gameObject.SetActive(true);
				Hearts.transform.Find("Heart2").Find("HF").gameObject.SetActive(true);
				Hearts.transform.Find("Heart2").Find("HM").gameObject.SetActive(true);
				Hearts.transform.Find("Heart2").Find("HN").gameObject.SetActive(true);
				Hearts.transform.Find("Heart1").Find("HF").gameObject.SetActive(true);
				Hearts.transform.Find("Heart1").Find("HM").gameObject.SetActive(true);
				Hearts.transform.Find("Heart1").Find("HN").gameObject.SetActive(true);
				Hearts.transform.Find("Heart0").Find("HF").gameObject.SetActive(true);
				Hearts.transform.Find("Heart0").Find("HM").gameObject.SetActive(true);
				Hearts.transform.Find("Heart0").Find("HN").gameObject.SetActive(true);
			}
			if(Health == 3f)
			{	
				Hearts.transform.Find("Heart3").Find("HF").gameObject.SetActive(false);
				Hearts.transform.Find("Heart3").Find("HM").gameObject.SetActive(false);
				Hearts.transform.Find("Heart3").Find("HN").gameObject.SetActive(true);
				Hearts.transform.Find("Heart2").Find("HF").gameObject.SetActive(true);
				Hearts.transform.Find("Heart2").Find("HM").gameObject.SetActive(true);
				Hearts.transform.Find("Heart2").Find("HN").gameObject.SetActive(true);
				Hearts.transform.Find("Heart1").Find("HF").gameObject.SetActive(true);
				Hearts.transform.Find("Heart1").Find("HM").gameObject.SetActive(true);
				Hearts.transform.Find("Heart1").Find("HN").gameObject.SetActive(true);
				Hearts.transform.Find("Heart0").Find("HF").gameObject.SetActive(true);
				Hearts.transform.Find("Heart0").Find("HM").gameObject.SetActive(true);
				Hearts.transform.Find("Heart0").Find("HN").gameObject.SetActive(true);
			}
			if(Health == 2.5f)
			{	
				Hearts.transform.Find("Heart3").Find("HF").gameObject.SetActive(false);
				Hearts.transform.Find("Heart3").Find("HM").gameObject.SetActive(false);
				Hearts.transform.Find("Heart3").Find("HN").gameObject.SetActive(true);
				Hearts.transform.Find("Heart2").Find("HF").gameObject.SetActive(false);
				Hearts.transform.Find("Heart2").Find("HM").gameObject.SetActive(true);
				Hearts.transform.Find("Heart2").Find("HN").gameObject.SetActive(true);
				Hearts.transform.Find("Heart1").Find("HF").gameObject.SetActive(true);
				Hearts.transform.Find("Heart1").Find("HM").gameObject.SetActive(true);
				Hearts.transform.Find("Heart1").Find("HN").gameObject.SetActive(true);
				Hearts.transform.Find("Heart0").Find("HF").gameObject.SetActive(true);
				Hearts.transform.Find("Heart0").Find("HM").gameObject.SetActive(true);
				Hearts.transform.Find("Heart0").Find("HN").gameObject.SetActive(true);
			}
			if(Health == 2f)
			{	
				Hearts.transform.Find("Heart3").Find("HF").gameObject.SetActive(false);
				Hearts.transform.Find("Heart3").Find("HM").gameObject.SetActive(false);
				Hearts.transform.Find("Heart3").Find("HN").gameObject.SetActive(true);
				Hearts.transform.Find("Heart2").Find("HF").gameObject.SetActive(false);
				Hearts.transform.Find("Heart2").Find("HM").gameObject.SetActive(false);
				Hearts.transform.Find("Heart2").Find("HN").gameObject.SetActive(true); 
				Hearts.transform.Find("Heart1").Find("HF").gameObject.SetActive(true);
				Hearts.transform.Find("Heart1").Find("HM").gameObject.SetActive(true);
				Hearts.transform.Find("Heart1").Find("HN").gameObject.SetActive(true);
				Hearts.transform.Find("Heart0").Find("HF").gameObject.SetActive(true);
				Hearts.transform.Find("Heart0").Find("HM").gameObject.SetActive(true);
				Hearts.transform.Find("Heart0").Find("HN").gameObject.SetActive(true);
			}
			if(Health == 1.5f)
			{	
				Hearts.transform.Find("Heart3").Find("HF").gameObject.SetActive(false);
				Hearts.transform.Find("Heart3").Find("HM").gameObject.SetActive(false);
				Hearts.transform.Find("Heart3").Find("HN").gameObject.SetActive(true);
				Hearts.transform.Find("Heart2").Find("HF").gameObject.SetActive(false);
				Hearts.transform.Find("Heart2").Find("HM").gameObject.SetActive(false);
				Hearts.transform.Find("Heart2").Find("HN").gameObject.SetActive(true);
				Hearts.transform.Find("Heart1").Find("HF").gameObject.SetActive(false);
				Hearts.transform.Find("Heart1").Find("HM").gameObject.SetActive(true);
				Hearts.transform.Find("Heart1").Find("HN").gameObject.SetActive(true);
				Hearts.transform.Find("Heart0").Find("HF").gameObject.SetActive(true);
				Hearts.transform.Find("Heart0").Find("HM").gameObject.SetActive(true);
				Hearts.transform.Find("Heart0").Find("HN").gameObject.SetActive(true);
			}
			if(Health == 1f)
			{	
				Hearts.transform.Find("Heart3").Find("HF").gameObject.SetActive(false);
				Hearts.transform.Find("Heart3").Find("HM").gameObject.SetActive(false);
				Hearts.transform.Find("Heart3").Find("HN").gameObject.SetActive(true);
				Hearts.transform.Find("Heart2").Find("HF").gameObject.SetActive(false);
				Hearts.transform.Find("Heart2").Find("HM").gameObject.SetActive(false);
				Hearts.transform.Find("Heart2").Find("HN").gameObject.SetActive(true);
				Hearts.transform.Find("Heart1").Find("HF").gameObject.SetActive(false);
				Hearts.transform.Find("Heart1").Find("HM").gameObject.SetActive(false);
				Hearts.transform.Find("Heart1").Find("HN").gameObject.SetActive(true);
				Hearts.transform.Find("Heart0").Find("HF").gameObject.SetActive(true);
				Hearts.transform.Find("Heart0").Find("HM").gameObject.SetActive(true);
				Hearts.transform.Find("Heart0").Find("HN").gameObject.SetActive(true);
			}
			if(Health == 0.5f)
			{	
				Hearts.transform.Find("Heart3").Find("HF").gameObject.SetActive(false);
				Hearts.transform.Find("Heart3").Find("HM").gameObject.SetActive(false);
				Hearts.transform.Find("Heart3").Find("HN").gameObject.SetActive(true);
				Hearts.transform.Find("Heart2").Find("HF").gameObject.SetActive(false);
				Hearts.transform.Find("Heart2").Find("HM").gameObject.SetActive(false);
				Hearts.transform.Find("Heart2").Find("HN").gameObject.SetActive(true);
				Hearts.transform.Find("Heart1").Find("HF").gameObject.SetActive(false);
				Hearts.transform.Find("Heart1").Find("HM").gameObject.SetActive(false);
				Hearts.transform.Find("Heart1").Find("HN").gameObject.SetActive(true);
				Hearts.transform.Find("Heart0").Find("HF").gameObject.SetActive(false);
				Hearts.transform.Find("Heart0").Find("HM").gameObject.SetActive(true);
				Hearts.transform.Find("Heart0").Find("HN").gameObject.SetActive(true);
			}
			if(Health <= 0f)
			{	
				Hearts.transform.Find("Heart3").Find("HF").gameObject.SetActive(false);
				Hearts.transform.Find("Heart3").Find("HM").gameObject.SetActive(false);
				Hearts.transform.Find("Heart3").Find("HN").gameObject.SetActive(true);
				Hearts.transform.Find("Heart2").Find("HF").gameObject.SetActive(false);
				Hearts.transform.Find("Heart2").Find("HM").gameObject.SetActive(false);
				Hearts.transform.Find("Heart2").Find("HN").gameObject.SetActive(true);
				Hearts.transform.Find("Heart1").Find("HF").gameObject.SetActive(false);
				Hearts.transform.Find("Heart1").Find("HM").gameObject.SetActive(false);
				Hearts.transform.Find("Heart1").Find("HN").gameObject.SetActive(true);
				Hearts.transform.Find("Heart0").Find("HF").gameObject.SetActive(false);
				Hearts.transform.Find("Heart0").Find("HM").gameObject.SetActive(false);
				Hearts.transform.Find("Heart0").Find("HN").gameObject.SetActive(true);
				GameEvents.GameOver?.Invoke();
			}
		}
		else
		{
			if (Health == 3f)
			{	
				Hearts.transform.Find("Heart3").Find("HF").gameObject.SetActive(false);
				Hearts.transform.Find("Heart3").Find("HM").gameObject.SetActive(false);
				Hearts.transform.Find("Heart3").Find("HN").gameObject.SetActive(false);
				Hearts.transform.Find("Heart2").Find("HF").gameObject.SetActive(true);
				Hearts.transform.Find("Heart2").Find("HM").gameObject.SetActive(true);
				Hearts.transform.Find("Heart2").Find("HN").gameObject.SetActive(true);
				Hearts.transform.Find("Heart1").Find("HF").gameObject.SetActive(true);
				Hearts.transform.Find("Heart1").Find("HM").gameObject.SetActive(true);
				Hearts.transform.Find("Heart1").Find("HN").gameObject.SetActive(true);
				Hearts.transform.Find("Heart0").Find("HF").gameObject.SetActive(true);
				Hearts.transform.Find("Heart0").Find("HM").gameObject.SetActive(true);
				Hearts.transform.Find("Heart0").Find("HN").gameObject.SetActive(true);
			}

			if (Health == 2.5f)
			{	
				Hearts.transform.Find("Heart3").Find("HF").gameObject.SetActive(false);
				Hearts.transform.Find("Heart3").Find("HM").gameObject.SetActive(false);
				Hearts.transform.Find("Heart3").Find("HN").gameObject.SetActive(false);
				Hearts.transform.Find("Heart2").Find("HF").gameObject.SetActive(false);
				Hearts.transform.Find("Heart2").Find("HM").gameObject.SetActive(true);
				Hearts.transform.Find("Heart2").Find("HN").gameObject.SetActive(true);
				Hearts.transform.Find("Heart1").Find("HF").gameObject.SetActive(true);
				Hearts.transform.Find("Heart1").Find("HM").gameObject.SetActive(true);
				Hearts.transform.Find("Heart1").Find("HN").gameObject.SetActive(true);
				Hearts.transform.Find("Heart0").Find("HF").gameObject.SetActive(true);
				Hearts.transform.Find("Heart0").Find("HM").gameObject.SetActive(true);
				Hearts.transform.Find("Heart0").Find("HN").gameObject.SetActive(true);
			}

			if (Health == 2f)
			{	
				Hearts.transform.Find("Heart3").Find("HF").gameObject.SetActive(false);
				Hearts.transform.Find("Heart3").Find("HM").gameObject.SetActive(false);
				Hearts.transform.Find("Heart3").Find("HN").gameObject.SetActive(false);
				Hearts.transform.Find("Heart2").Find("HF").gameObject.SetActive(false);
				Hearts.transform.Find("Heart2").Find("HM").gameObject.SetActive(false);
				Hearts.transform.Find("Heart2").Find("HN").gameObject.SetActive(true);
				Hearts.transform.Find("Heart1").Find("HF").gameObject.SetActive(true);
				Hearts.transform.Find("Heart1").Find("HM").gameObject.SetActive(true);
				Hearts.transform.Find("Heart1").Find("HN").gameObject.SetActive(true);
				Hearts.transform.Find("Heart0").Find("HF").gameObject.SetActive(true);
				Hearts.transform.Find("Heart0").Find("HM").gameObject.SetActive(true);
				Hearts.transform.Find("Heart0").Find("HN").gameObject.SetActive(true);
			}

			if (Health == 1.5f)
			{	
				Hearts.transform.Find("Heart3").Find("HF").gameObject.SetActive(false);
				Hearts.transform.Find("Heart3").Find("HM").gameObject.SetActive(false);
				Hearts.transform.Find("Heart3").Find("HN").gameObject.SetActive(false);
				Hearts.transform.Find("Heart2").Find("HF").gameObject.SetActive(false);
				Hearts.transform.Find("Heart2").Find("HM").gameObject.SetActive(false);
				Hearts.transform.Find("Heart2").Find("HN").gameObject.SetActive(true);
				Hearts.transform.Find("Heart1").Find("HF").gameObject.SetActive(false);
				Hearts.transform.Find("Heart1").Find("HM").gameObject.SetActive(true);
				Hearts.transform.Find("Heart1").Find("HN").gameObject.SetActive(true);
				Hearts.transform.Find("Heart0").Find("HF").gameObject.SetActive(true);
				Hearts.transform.Find("Heart0").Find("HM").gameObject.SetActive(true);
				Hearts.transform.Find("Heart0").Find("HN").gameObject.SetActive(true);
			}

			if (Health == 1f)
			{	
				Hearts.transform.Find("Heart3").Find("HF").gameObject.SetActive(false);
				Hearts.transform.Find("Heart3").Find("HM").gameObject.SetActive(false);
				Hearts.transform.Find("Heart3").Find("HN").gameObject.SetActive(false);
				Hearts.transform.Find("Heart2").Find("HF").gameObject.SetActive(false);
				Hearts.transform.Find("Heart2").Find("HM").gameObject.SetActive(false);
				Hearts.transform.Find("Heart2").Find("HN").gameObject.SetActive(true);
				Hearts.transform.Find("Heart1").Find("HF").gameObject.SetActive(false);
				Hearts.transform.Find("Heart1").Find("HM").gameObject.SetActive(false);
				Hearts.transform.Find("Heart1").Find("HN").gameObject.SetActive(true);
				Hearts.transform.Find("Heart0").Find("HF").gameObject.SetActive(true);
				Hearts.transform.Find("Heart0").Find("HM").gameObject.SetActive(true);
				Hearts.transform.Find("Heart0").Find("HN").gameObject.SetActive(true);
			}

			if (Health == 0.5f)
			{	
				Hearts.transform.Find("Heart3").Find("HF").gameObject.SetActive(false);
				Hearts.transform.Find("Heart3").Find("HM").gameObject.SetActive(false);
				Hearts.transform.Find("Heart3").Find("HN").gameObject.SetActive(false);
				Hearts.transform.Find("Heart2").Find("HF").gameObject.SetActive(false);
				Hearts.transform.Find("Heart2").Find("HM").gameObject.SetActive(false);
				Hearts.transform.Find("Heart2").Find("HN").gameObject.SetActive(true);
				Hearts.transform.Find("Heart1").Find("HF").gameObject.SetActive(false);
				Hearts.transform.Find("Heart1").Find("HM").gameObject.SetActive(false);
				Hearts.transform.Find("Heart1").Find("HN").gameObject.SetActive(true);
				Hearts.transform.Find("Heart0").Find("HF").gameObject.SetActive(false);
				Hearts.transform.Find("Heart0").Find("HM").gameObject.SetActive(true);
				Hearts.transform.Find("Heart0").Find("HN").gameObject.SetActive(true);
			}

			if (Health <= 0f)
			{
				Hearts.transform.Find("Heart3").Find("HF").gameObject.SetActive(false);
				Hearts.transform.Find("Heart3").Find("HM").gameObject.SetActive(false);
				Hearts.transform.Find("Heart3").Find("HN").gameObject.SetActive(false);
				Hearts.transform.Find("Heart2").Find("HF").gameObject.SetActive(false);
				Hearts.transform.Find("Heart2").Find("HM").gameObject.SetActive(false);
				Hearts.transform.Find("Heart2").Find("HN").gameObject.SetActive(true);
				Hearts.transform.Find("Heart1").Find("HF").gameObject.SetActive(false);
				Hearts.transform.Find("Heart1").Find("HM").gameObject.SetActive(false);
				Hearts.transform.Find("Heart1").Find("HN").gameObject.SetActive(true);
				Hearts.transform.Find("Heart0").Find("HF").gameObject.SetActive(false);
				Hearts.transform.Find("Heart0").Find("HM").gameObject.SetActive(false);
				Hearts.transform.Find("Heart0").Find("HN").gameObject.SetActive(true);
				GameEvents.GameOver?.Invoke();
			}
		}
	}
}
