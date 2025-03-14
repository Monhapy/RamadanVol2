using UnityEngine;
using UnityEngine.UI;

public class CookFood : MonoBehaviour
{
    
    
    
    public float cookingTime = 0; // Geçen süre
    public float maxCookingTime = 15f; // Toplam pişirme süresi
    public Slider cookingBar; // UI'deki Slider bileşeni
    public Transform newPosition; // Objenin yeni konumu

    private bool isCooking = false; // Sayaç çalışıyor mu kontrolü

    void Update()
    {
        if (isCooking)
        {
            cookingTime += Time.deltaTime; // Süreyi artır
            cookingBar.value = cookingTime / maxCookingTime; // Slider'ı güncelle

            if (cookingTime >= maxCookingTime)
            {
                FinishCooking();
            }
        }
    }

    void OnMouseDown()
    {
        if (!isCooking)
        {
            isCooking = true;
            cookingTime = 0;
            cookingBar.gameObject.SetActive(true); // UI Barını görünür yap
            cookingBar.value = 0; // Barı sıfırla
        }
    }

    void FinishCooking()
    {
        isCooking = false;
        cookingBar.gameObject.SetActive(false); // UI Barını sakla
        transform.position = newPosition.position; // Yeni konuma taşı
    }
}
