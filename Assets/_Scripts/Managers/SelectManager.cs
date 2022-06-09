using UnityEngine;

public class SelectManager : MonoBehaviour
{
    [Header("Cameras")] 
    [SerializeField] private Camera mainCamera;

    [Header("Selected Object"), Space] 
    public GameObject selectedGo;
    
    // Properties
    private Vector2 MouseScreenPos => mainCamera.ScreenToWorldPoint(Input.mousePosition);

    private void Update() => UpdateInit();

    private void UpdateInit()
    {
        SelectCaseRay();
    }

    private void SelectCaseRay()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var hit = Physics2D.Raycast(MouseScreenPos, Vector2.zero);
            
            if(hit.collider == null) return;
            SelectCase(hit);
        }
    }

    private void SelectCase(RaycastHit2D hit)
    {
        switch (hit.collider.tag)
        {
            case "Penguin":
                if (selectedGo == null)
                {
                    selectedGo = hit.collider.gameObject;
                    selectedGo.GetComponent<PlayerMovement>().ButtonsActivator();
                }
                else
                {
                    selectedGo.GetComponent<PlayerMovement>().AllButtonInActive();
                    if (hit.collider.gameObject == selectedGo)
                    {
                        selectedGo = null;
                    }
                    else
                    {
                        selectedGo = hit.collider.gameObject;
                        selectedGo.GetComponent<PlayerMovement>().ButtonsActivator();
                    }
                }
                break;
            case "Seal":
                if (selectedGo == null)
                {
                    selectedGo = hit.collider.gameObject;
                    selectedGo.GetComponent<PlayerMovement>().ButtonsActivator();
                }
                else
                {
                    selectedGo.GetComponent<PlayerMovement>().AllButtonInActive();
                    if (hit.collider.gameObject == selectedGo)
                    {
                        selectedGo = null;
                    }
                    else
                    {
                        selectedGo = hit.collider.gameObject;
                        selectedGo.GetComponent<PlayerMovement>().ButtonsActivator();
                    }
                }
                break;
        }
    }
}
