﻿using RoR2;
using System;
using UnityEngine;

namespace SavedGames.Data {
    [Serializable]
    public class ShrineRestackData {
        private const string Path = "SpawnCards/InteractableSpawnCard/iscShrineRestack";

        public SerializableTransform transform;

        public bool available;

        public static ShrineRestackData SaveShrineRestack(ShrineRestackBehavior shrine) {
            var shrineRestackData = new ShrineRestackData();
            var purchaseInteraction = shrine.GetComponent<PurchaseInteraction>();

            shrineRestackData.transform = new SerializableTransform(shrine.transform);
            shrineRestackData.available = purchaseInteraction.available;

            return shrineRestackData;
        }

        public void LoadShrineRestack() {
            var gameobject = Resources.Load<SpawnCard>(Path).DoSpawn(transform.position.GetVector3(), transform.rotation.GetQuaternion());
            var shrine = gameobject.GetComponent<ShrineRestackBehavior>();
            var purchaseInteraction = shrine.GetComponent<PurchaseInteraction>();

            purchaseInteraction.SetAvailable(available);

        }

    }
}
