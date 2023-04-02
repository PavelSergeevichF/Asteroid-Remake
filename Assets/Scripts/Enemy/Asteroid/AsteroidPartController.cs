using UnityEngine;

public class AsteroidPartController : IDestroy
{

    private bool _setNewVector = true;

    private AsteroidPartView _asteroidPartView;

    private MoveController _moveController;


    public AsteroidPartController(AsteroidPartView asteroidPartView)
    {
        _asteroidPartView = asteroidPartView;
        _moveController = new MoveController(_asteroidPartView.gameObject);
    }

    public void Execute()
    {
        Move();
        CheckPose();
    }
    private void Move()
    {
        if (_setNewVector)
        {
            _setNewVector = false;
            _moveController.SetTargrt();
        }
        _moveController.MovingForward(_asteroidPartView.SOEnemyBase.Speed);
    }
    public void CollisionGO(Collision2D collision)
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
    private void CheckPose()
    {
        if (_asteroidPartView.gameObject.transform.position.x > _asteroidPartView.SOEnemyBase.MaxPos.x || _asteroidPartView.gameObject.transform.position.x < _asteroidPartView.SOEnemyBase.MinPos.x)
            Destroy();
        if (_asteroidPartView.gameObject.transform.position.y > _asteroidPartView.SOEnemyBase.MaxPos.y || _asteroidPartView.gameObject.transform.position.y < _asteroidPartView.SOEnemyBase.MinPos.y)
            Destroy();
    }
    public void DestroyView()
    {
        _asteroidPartView.SOPlayerModel.Score += _asteroidPartView.SOEnemyBase.Score;
        Destroy();
    }
    private void Destroy()
    {
        _asteroidPartView.DeliteGameObject();
    }
}
