using UnityEngine;

public interface IEnemy {

    ObjectTypes objectID { get; }
    void DestroyMe();
    void DestroyVisualEffect();

}
