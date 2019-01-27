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

        public List<Identity> Identities { get; private set; }
        public List<Player> Players { get; private set; }

        public List<Transform> SpawnRegions
        {
            get { return SpawnRegionTransforms.ToList(); }
        }

        private void Awake()
        {
            Identities = new List<Identity>();

            var player1 = gameObject.AddComponent<Player>();
            player1.GameManager = this;

            Players = new List<Player>
            {
                player1,
            };
        }

        public Invader SpawnInvader()
        {
            var spawnPoint = SpawnRegionTransforms[UnityEngine.Random.Range(0, SpawnRegionTransforms.Length - 1)];

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

        public Guardian SpawnGuardian(Identity identity)
        {
            identity.Score += CalculateInvaderScore();

            var spawnPoint = GoalRegionTransform;

            GameObject clone;
            switch (identity.Type)
            {
                case FruitType.Orange:
                default:
                    clone = Instantiate(OrangeGuardianPrefab, spawnPoint.position, spawnPoint.rotation);
                    break;
            }

            var guardian = clone.GetComponent<Guardian>();
            guardian.Identity = identity;

            return guardian;
        }

        public void RemoveIdentity(Identity identity)
        {
            Identities.Remove(identity);
        }

        private int CalculateInvaderScore()
        {
            return 1 + Identities.Count - Players.Count(p => p.State == Player.PlayerState.Invading);
        }
    }
}
