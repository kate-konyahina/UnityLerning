using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TopDownZenject
{
    public class CoinFactory : PlaceholderFactory<Coin>
    {
        
        public override Coin Create()
        {          
                var coin = base.Create();
                var randomPointInCircle = Random.insideUnitCircle * 10f;
                coin.transform.position = new Vector3(randomPointInCircle.x, 0.75f, randomPointInCircle.y); ;
                return coin;
        }
    }
}
