using System.Collections.Generic;
using UnityEngine;

public class DamagePopup : MonoBehaviour
{
    [SerializeField] List<Sprite> signs = new List<Sprite>();
    [SerializeField] SpriteRenderer signSR;
    [SerializeField] Counter counter;
    [SerializeField] float speed;

    public static void CreatePopup(Vector2 position, int value, bool positive = false)
    {
        GameObject popup = Instantiate(GameAssets.instance.GetGameObject("popup"), position + new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)), Quaternion.identity);
        popup.GetComponent<DamagePopup>().SetPopup(value.ToString(), positive);
        Destroy(popup, 0.5f);
    }

    public void SetPopup(string value, bool positive = false)
    {
        signSR.sprite = signs[positive ? 0 : 1];
        counter.SetText(value, positive ? 2 : 0);
    }

    private void Update()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;
    }
}
