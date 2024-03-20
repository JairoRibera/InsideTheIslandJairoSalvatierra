using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    Collider2D _platformCollider;
    bool _onPlatform = false;
    // Start is called before the first frame update
    void Start()
    {
        _platformCollider = GetComponent<EdgeCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxisRaw("Vertical") < -0.5f && _onPlatform)
        {
            StartCoroutine(ActDeactPlatformCo());
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            _onPlatform = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            _onPlatform = false;
    }
    IEnumerator ActDeactPlatformCo()
    {
        _platformCollider.enabled = false;
        yield return new WaitForSeconds(.5f);
        _platformCollider.enabled = true;
    }
}
