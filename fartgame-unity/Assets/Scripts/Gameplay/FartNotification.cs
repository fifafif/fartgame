using System.Collections;
using UnityEngine;

public class FartNotification : MonoBehaviour
{
    public GameObject FarterDiscovered;
    public GameObject FartSmelled;

    private Coroutine hideCoroutine;

    public enum Type
    {
        Smelled,
        Discovered,
    }

    private void Start()
    {
        Hide();
    }

    public void ShowNotification(Type type)
    {
        FarterDiscovered.SetActive(type == Type.Discovered);
        FartSmelled.SetActive(type == Type.Smelled);

        if (hideCoroutine != null)
        {
            StopCoroutine(hideCoroutine);
        }

        hideCoroutine = StartCoroutine(HideAsync());
    }

    private IEnumerator HideAsync()
    {
        yield return new WaitForSeconds(2f);

        Hide();
    }

    private void Hide()
    {
        FarterDiscovered.SetActive(false);
        FartSmelled.SetActive(false);
    }
}
