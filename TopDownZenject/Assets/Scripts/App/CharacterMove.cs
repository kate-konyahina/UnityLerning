using UnityEngine;
using UnityEngine.AI;


namespace TopDownZenject
{

    public class CharacterMove : MonoBehaviour, ICharacterMove
    {
        //  private bool _isMoving;
        //[SerializeField] private int _circleSize = 10;
        //[SerializeField] private int _speed = 3;
        // private Vector3 _newDestination;
        //private readonly WaitForSeconds _waitForSeconds = new(3);

        [SerializeField] private NavMeshAgent _agent;

        public Vector3 GetCurrentPosition()
        {
            return transform.position;
        }

        // Save this logic for enemies
        //public void StartMove()
        //{
           // StartCoroutine(ChangeDestination());
            //_isMoving = true;
        //}

        private void Update()
        {

            // Save this logic for enemies
            // if( _isMoving)
            //{
            //transform.position = Vector3.MoveTowards(transform.position, _newDestination, Time.deltaTime * _speed);
            // }
        }

        public void MoveTo(Vector3 pos)
        {
            _agent.SetDestination(pos);
        }

        // Save this logic for enemies
        //private IEnumerator ChangeDestination()
        //{
        // var randomPointinCerle = Random.insideUnitCircle;
        //_newDestination = new Vector3(randomPointinCerle.x, 0, randomPointinCerle.y) * _circleSize;
        // yield return _waitForSeconds;
        // StartCoroutine(ChangeDestination());
        //}
    }
}
