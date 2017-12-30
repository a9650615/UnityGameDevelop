using UnityEngine;
using System.Collections;
using Game;

namespace Game.Entity {
    public static class RendererExtensions
    {
        public static bool IsVisibleFrom(this Renderer renderer, Camera camera)
        {
            Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);
            return GeometryUtility.TestPlanesAABB(planes, renderer.bounds);
        }
    }

    public class MonsterCreator : MonoBehaviour
    {
        float createTime = 5;
        private float timeCounter;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            timeCounter += Time.deltaTime;

            //Debug.Log(GameCore.GetSystem<CreatorSystem>().GetTypeList("Monster").Count);
            if (timeCounter > createTime && GameCore.GetSystem<CreatorSystem>().GetTypeList("Monster").Count < 40)
            {
                if (!gameObject.GetComponent<Renderer>().IsVisibleFrom(Camera.main))
               {
                    GameObject monster = GameCore.GetSystem<CreatorSystem>().AppendGameObject(GameCore.GetSystem<ResourceSystem>().GetResource("Monster"), "Monster");
                    monster.transform.position = gameObject.transform.position + new Vector3(Random.Range(-5.0f, 5.0f), Random.Range(-1.0f, 1.0f), -1f);
                }
                timeCounter = 0;
            }
        }
    }
}
