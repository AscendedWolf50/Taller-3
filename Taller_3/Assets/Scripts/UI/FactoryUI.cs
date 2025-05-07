using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FactoryUI : MonoBehaviour
{
    public GameObject cubePrefab;
    public GameObject spherePrefab;
    public GameObject capsulePrefab;

    public Button cubeButton;
    public Button sphereButton;
    public Button capsuleButton;
    public Button spawnButton;
    public Button backButton;

    private SpawnFacade facade;

    void Start()
    {
        facade = new SpawnFacade();
        facade.RegisterFactory("Cube", new CubeFactory(cubePrefab));
        facade.RegisterFactory("Sphere", new SphereFactory(spherePrefab));
        facade.RegisterFactory("Capsule", new CapsuleFactory(capsulePrefab));

        cubeButton.onClick.AddListener(() => facade.SetCurrentType("Cube"));
        sphereButton.onClick.AddListener(() => facade.SetCurrentType("Sphere"));
        capsuleButton.onClick.AddListener(() => facade.SetCurrentType("Capsule"));
        spawnButton.onClick.AddListener(() => facade.Spawn());
        backButton.onClick.AddListener(() => SceneManager.LoadScene("MainMenu"));
    }
}
