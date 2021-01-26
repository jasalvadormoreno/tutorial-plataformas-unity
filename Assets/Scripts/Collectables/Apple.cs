using UnityEngine;

public class Apple : MonoBehaviour, ICollectable
{
    private Transform collectTransform;

    private bool _collected;
    private float speed = 10;

    private void Start()
    {
        collectTransform = GameObject.Find("CollectTransform").transform;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (_collected)
        {
            transform.position = Vector3.MoveTowards(transform.position, collectTransform.position, Time.deltaTime * speed);
        }

        if (transform.position == collectTransform.position)
        {
            UIManager.Instance.AddApple();
            Destroy(gameObject);
        }
    }

    public void Collect()
    {
        _collected = true;
    }
}
