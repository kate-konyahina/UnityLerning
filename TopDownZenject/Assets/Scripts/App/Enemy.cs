using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace TopDownZenject
{
   
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _agent;
        private ICharacterMove _character;
        private EnemyInfo _enemyInfo;
        public bool _followPlayer;
        private GamePanel _gamePanel;
        public int _health;
        public GameObject _particle;

        [Inject]
        private void Construct(ICharacterMove character, GamePanel gamePanel)
        {
         _character = character;   
         _gamePanel = gamePanel;
        }

       public void Init(EnemyInfo enemyInfo)
       {
          _enemyInfo = enemyInfo;
          _followPlayer = true;
          _health = enemyInfo.Health;
          _particle = enemyInfo.Particle;           
       }

        public void Update()
        {
           float distance = Vector3.Distance(transform.position, _character.GetCurrentPosition());

            if (_followPlayer)
            {
                if (distance < _enemyInfo.Vision) FollowPlayer();
            } 

            if(_health < 1)
            {
                Instantiate(_particle,transform.position, Quaternion.identity);
                Debug.Log("Death");
                Destroy(gameObject);
            }
        }

        private void FollowPlayer()
        {
            _agent.SetDestination(_character.GetCurrentPosition());
        }

        public void OnTriggerEnter(Collider collider)
        {
            if (collider.gameObject.CompareTag("Player")) 
            {
               _gamePanel.UpdateDefeatState();
            } 

            if (collider.gameObject.CompareTag("Deadzone"))
            {
               
                Debug.Log("Collision");
                _health--;
            }

        }
                
      
  


    }
}
