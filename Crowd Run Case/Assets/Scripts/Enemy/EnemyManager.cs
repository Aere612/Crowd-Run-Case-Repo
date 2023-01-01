using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyManager : MonoBehaviour
{
    #region Variables
    #region Gizmos
    [Range(1f , 10f)][SerializeField] float radius;
    [SerializeField] bool drawGizmos;
    #endregion
    #region Amount
    public int amountOfEnemy;
    #endregion
    #region Serialized
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float distanceToAttack = 15;
    #endregion
    #region Player in scene
    public GameObject player;
    #endregion
    #region NonSerialized
    [NonSerialized] public int livingEnemy = 0;
    [NonSerialized] public bool attacking = false;
    #endregion
    #region Temp
    Vector3 radiusTemp;
    #endregion
    public LeadManager leadManager;
    public Movement movement;
    #endregion

    #region Unity functions
    private void Awake()
    {
        while (livingEnemy < amountOfEnemy)
            SpawnEnemy();
    }
    void Update()
    {
        //TODO:Eðer playerýn yarýçapý belli ise bu satýrý yorum satýrý yapmaktan çýkarýn ve playerRadius yerine player'ýn yarýçapýný yazýn
        //distanceToAttack = playerRadius / 2 + radius / 2;

        //Saldýrýya baþlamak için gereken uzaklýk
        if (Vector3.Distance(transform.position, player.transform.position) < distanceToAttack && attacking == false)
        {
            movement.CanMove = false;
            attacking = true;
        }
        
        //Eðer düþman kalmazsa kendini yok et
        if(amountOfEnemy <= 0)
            Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        if(drawGizmos) Gizmos.DrawSphere(transform.position, -radius);
    }
    #endregion
    private void SpawnEnemy()
    {
        #region Random position
        //set random position to spawn
        radiusTemp.x = Random.Range(-radius / 2, radius / 2);
        radiusTemp.z = Random.Range(-radius / 2, radius / 2);

        //Make spawn position circle
        radiusTemp.Normalize();

        //increase spawn radius
        radiusTemp *= radius / 2;

        //fill in the circle
        radiusTemp = radiusTemp * Random.Range(0, 100) / 100;
        
        //set y pos
        radiusTemp.y = 1;
        #endregion
        //Creating game object
        GameObject temp = Instantiate(enemyPrefab, transform.position + radiusTemp, new Quaternion());
        
        //Setting Enemy script
        temp.GetComponent<Enemy>().manager = GetComponent<EnemyManager>();
        
        //Increasing living enemy amount
        this.livingEnemy++;
    }
    ~EnemyManager()
    {
        movement.CanMove = true;
    }
}
