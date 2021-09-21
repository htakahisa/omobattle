using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetBattleResultRes
{
    public string battleResultId;

    public string battleResultStatus;

    public List<BattleResult> results = new List<BattleResult>();


    [Serializable]
    public class BattleResult {

        public ResultAction change;

        public ResultAction inTheBattle;

        public ResultAction beforeAttack;

        public ResultAction inAttack;

        public ResultAction afterAttack;

        public ResultAction endTheBattle;
    }

    [Serializable]
    public class ResultAction {

        public string message1;

        public string message2;

        public string action;  // ClientAction

        public CharacterStatusEntity characterStatus1;

        public CharacterStatusEntity characterStatus2;

    }

    [Serializable]
    public class CharacterStatusEntity {
        public long id;

        public long characterId;

        public string roomId;

        public string userId;

        public long turnCount;

        public string name;

        public long hp;

        public long orgHp;

        // 攻撃
        public long attack;

        // すばやさ
        public long speed;

        // 回避率
        public double dodgeRate;

        public string specialAbility;
        public string appendEffect;

        public double attackRate;
        public double speedRate;

    }
}
