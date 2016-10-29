using UnityEngine;
using System.Collections;

// enemy랜덤으로 생성
public class EnemyGod : MonoBehaviour
{
    public GameObject enemyPrefab;
    public static int enemyNum = 0;
    static int ENEMY_MAX = 3;

    float currntTime = 0;
    float randomTime = 0;

    public float MAX_RANDOM = 0.5f;
    public float MIN_RANDOM = 0;

    // 랜덤함수를 이용해서 enemy를 생성point에 랜덤으로 생성하는데,
    // 생성point는 여러곳이고, 그 중 몇곳만 나타나게 하고 싶음
    // 그래서 그걸 또 리셋하고 다시 시작하면 아까와 다른 몇곳에서 나타나게

    void Start()
    {
        randomTime = Random.Range(MIN_RANDOM, MAX_RANDOM);
        Invoke("MakeEnemy", randomTime);
    }
    void MakeEnemy() {
        if (enemyNum < ENEMY_MAX)
        {
            GameObject enemy = Instantiate(enemyPrefab);
            enemy.transform.position = gameObject.transform.position;
            enemyNum++;
            randomTime = 0;
        }
    }
}
 