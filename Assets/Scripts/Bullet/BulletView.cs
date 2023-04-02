using UnityEngine;

public class BulletView : MonoBehaviour
{
    [SerializeField] private SOBullet _sOBullet;
    [SerializeField] private GameObject _player;

    private BulletController _bulletController;
    public SOBullet SOBullet => _sOBullet;
    public GameObject Player => _player;

    private void Awake()
    {
        _bulletController = new BulletController(this);
    }
    private void FixedUpdate()
    {
        _bulletController.Execute();
    }
    public void Activation() => _bulletController.Activation();
    public void DestroyView() => _bulletController.DestroyView();
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            _bulletController.DestroyView();
        }
    }
}
