using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GetBattleStatusRes
{
    //// Start is called before the first frame update
    //public string battleResultStatus;


    public UserStatus user1;
    public UserStatus user2;


    public UserStatus getUserStatus(String userId) {
        if (user1.userId.Equals(userId)) {
            return user1;
        } else if (user2.userId.Equals(userId)) {
            return user2;
        }
        return null;
    }

    [Serializable]
    public class UserStatus {
        public string userId;
        public string battleResultStatus;
        public string battleResultStatusOld;
        public long selectedCharacterId;

        public long characterId1;
        public long characterId2;
        public long characterId3;

        public bool aliveCharacter1;
        public bool aliveCharacter2;
        public bool aliveCharacter3;


        public Boolean isAlive(long characterId) {
            if (characterId1 == characterId) {
                return aliveCharacter1;
            } else if (characterId2 == characterId) {
                return aliveCharacter2;
            } else if (characterId3 == characterId) {
                return aliveCharacter3;
            }
            return false;
        }
    }
}
