using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderManager : MonoBehaviour {
    [Header("Dependencies")]
    public LoadingScreenUI loadingScreenUI;

    private LoadSceneRequest _pendingRequest;

    // Function that will be called from a listener
    public void OnLoadMenuRequest(LoadSceneRequest request) {
        if(!IsSceneAlreadyLoaded(request.scene)) {
            // Menus are loaded instantly
            SceneManager.LoadScene(request.scene.sceneName);
        }
    }

    // Function that will be called from a listener
    public void OnLoadLevelRequest(LoadSceneRequest request) {
        if(IsSceneAlreadyLoaded(request.scene)) {
            // Level is already loaded. Activate it
            ActivateLevel(request);
        } else {
            LoadScene(request);
        }
    }
    public void OnReloadLevelRequest(LoadSceneRequest request) {
        LoadScene(request);
    }
    private void LoadScene(LoadSceneRequest request) {
        if(request.loadingScreen) {
            // If a loading screen is requested, then show it and wait
            this._pendingRequest = request;
            this.loadingScreenUI.ToggleScreen(true);
        } else {
            // If no loading screen requeste, load it ASAP
            StartCoroutine(ProcessLevelLoading(request));
        }
    }

    // Function that will be called from a listener
    public void OnLoadingScreenToggled(bool enabled) {
        if(enabled && this._pendingRequest != null) {
            // When loading screen is shown, we receive the event and can load the new level
            StartCoroutine(ProcessLevelLoading(this._pendingRequest));
        }
    }

    private bool IsSceneAlreadyLoaded(SceneSO scene) {
        Scene loadedScene = SceneManager.GetSceneByName(scene.name);

        return loadedScene != null && loadedScene.isLoaded;
    }

    private IEnumerator ProcessLevelLoading(LoadSceneRequest request) {
        if(request.scene != null) {
            var currentLoadedLevel = SceneManager.GetActiveScene();
            SceneManager.UnloadSceneAsync(currentLoadedLevel);

            AsyncOperation loadSceneProcess = SceneManager.LoadSceneAsync(request.scene.name, LoadSceneMode.Additive);

            // Level is being loaded, it could take some seconds (or not). Waiting until is fully loaded
            while(!loadSceneProcess.isDone) {
                yield return null;
            }

            // Once the level is ready, activate it!
            ActivateLevel(request);
        }
    }

    private void ActivateLevel(LoadSceneRequest request) {
        // Set active
        Scene loadedLevel = SceneManager.GetSceneByName(request.scene.name);
        SceneManager.SetActiveScene(loadedLevel);

        // Hide black loading screen
        if(request.loadingScreen) {
            this.loadingScreenUI.ToggleScreen(false);
        }

        // Clean status
        this._pendingRequest = null;
    }
}
