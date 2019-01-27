using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Fruitz;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameManager : MonoBehaviour
    {
        public Transform[] SpawnRegionTransforms;
        public Transform GoalRegionTransform;
        public GameObject OrangeGuardianPrefab;
        public GameObject OrangeInvaderPrefab;

        public List<Identity> Identities { get; set; }

        public List<Transform> SpawnRegions
        {
            get { return SpawnRegionTransforms.ToList(); }
        }

        public Invader SpawnInvader()
        {
            var spawnPoint = SpawnRegionTransforms[UnityEngine.Random.Range(0, SpawnRegionTransforms.Length)];

            var identity = Identity.GenerateNewIdentity();
            Identities.Add(identity);

            GameObject clone;
            switch (identity.Type)
            {
                case FruitType.Orange:
                default:
                    clone = Instantiate(OrangeInvaderPrefab, spawnPoint.position, spawnPoint.rotation);
                    break;
            }

            var invader = clone.GetComponent<Invader>();
            invader.Identity = identity;

            return invader;
        }

        public Turret SpawnGuardian(Identity identity)
        {
            var spawnPoint = GoalRegionTransform;

            GameObject clone;
            switch (identity.Type)
            {
                case FruitType.Orange:
                default:
                    clone = Instantiate(OrangeGuardianPrefab, spawnPoint.position, spawnPoint.rotation);
                    break;
            }

            var guardian = clone.GetComponent<Turret>();
            guardian.Identity = identity;

            return guardian;
        }
    }
}
