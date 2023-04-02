using UnityEngine;

public class UFOController
{
    private bool _active = false;
    private GameObject _player;

    private UFOView _uFOView;
    private MoveController _moveController;

    public UFOController(UFOView uFOView, GameObject player)
    {
        _uFOView = uFOView;
        _player = player;
        _moveController = new MoveController(uFOView.gameObject);
    }

    public void Execute()
    {
        if (_active)
        {
            Move();
        }
    }
    private void Move()
    {
        _moveController.MovingTarget(_uFOView.SOEnemyBase.Speed, _player);
    }
    public void Activation() 
    {
        _active=true;
    }
    public void CollisionGO(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Player":
                {
                    collision.gameObject.GetComponent<PlayerView>().CollisionEnter();
                    DestroyView();
                }
                break;
            case "Bullet":
                {
                    collision.gameObject.GetComponent<BulletView>().DestroyView();
                    DestroyView();
                }
                break;
            case "Laser":
                {
                    DestroyView();
                }
                break;
        };
    }
    public void DestroyView()
    {
        _player.GetComponent<PlayerView>().SOPlayerModel.Score += _uFOView.SOEnemyBase.Score;
        _active = false;
        _uFOView.gameObject.SetActive(false);
    }
}
