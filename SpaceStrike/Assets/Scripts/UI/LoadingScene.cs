using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    public static LoadingScene instance;
    
    [Header("Menu")]
    public GameObject loadingScreen;  // Menggunakan single GameObject untuk simplicity
    [SerializeField] private Slider loadingSlider;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadNewGame(int levelToLoad)
    {
        loadingScreen.SetActive(true);


        StartCoroutine(AnimateSliderAndLoadLevel(levelToLoad));
    }

    IEnumerator AnimateSliderAndLoadLevel(int levelToLoad)
    {
        // Penundaan untuk memperlihatkan animasi slider
        for (float i = 0; i <= 1; i += 0.01f)
        {
            loadingSlider.value = i;
            yield return new WaitForSeconds(0.05f); // Penundaan animasi slider
        }

        // Memulai proses loading scene yang sebenarnya
        StartCoroutine(LoadLevel(levelToLoad));
    }

    IEnumerator LoadLevel(int levelToLoad)
    {
        AsyncOperation lp = SceneManager.LoadSceneAsync(levelToLoad);

        // Penundaan opsional setelah scene baru dimuat
        yield return new WaitForSeconds(1f);

        loadingScreen.SetActive(false);


    }
}
