using UnityEngine;
using UnityEngine.UI;

public class WaterDispenser : MonoBehaviour
{
	public Slider waterBar; // UI üzerindeki slider
	public float fillSpeed = 1f; // Barın dolma hızı
	private bool isFilling = false; // AI su içiyor mu?

	private void Start()
	{
		waterBar.gameObject.SetActive(false); // Başlangıçta UI kapalı
		waterBar.value = 0; // Slider sıfırdan başlasın
	}

	private void Update()
	{
		if (isFilling)
		{
			waterBar.value += fillSpeed * Time.deltaTime;

			if (waterBar.value >= waterBar.maxValue)
			{
				Debug.Log("Su içme tamamlandı!");
				isFilling = false; // Dolduğunda doldurmayı durdur
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("AI"))
		{
			waterBar.gameObject.SetActive(true); // Barı aç
			isFilling = true;
			Debug.Log("AI su içmeye başladı.");
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag("AI"))
		{
			waterBar.gameObject.SetActive(false); // Barı gizle
			waterBar.value = 0; // Barı sıfırla
			isFilling = false;
			Debug.Log("AI su içmeyi bıraktı.");
		}
	}
}
