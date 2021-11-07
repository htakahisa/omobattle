using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionFactory
{


    public static List<Actions> actions(GetBattleResultRes.BattleResult battleResult) {

        List<Actions> actionList = new List<Actions>();

        if (battleResult.change.message1 != null) {
            actionList.Add(new MessageAction(battleResult.change.message1));
        }
        if (battleResult.change.message2 != null) {
            actionList.Add(new MessageAction(battleResult.change.message1));
        }

        if (battleResult.inTheBattle.message1 != null) {
            actionList.Add(new MessageAction(battleResult.inTheBattle.message1));
        }
        if (battleResult.inTheBattle.message2 != null) {
            actionList.Add(new MessageAction(battleResult.inTheBattle.message1));
        }

        if (battleResult.beforeAttack.message1 != null) {
            actionList.Add(new MessageAction(battleResult.beforeAttack.message1));
        }
        if (battleResult.beforeAttack.message2 != null) {
            actionList.Add(new MessageAction(battleResult.beforeAttack.message1));
        }

        if (battleResult.inAttack.message1 != null) {
            actionList.Add(new MessageAction(battleResult.inAttack.message1));
        }
        if (battleResult.inAttack.message2 != null) {
            actionList.Add(new MessageAction(battleResult.inAttack.message1));
        }

        if (battleResult.afterAttack.message1 != null) {
            actionList.Add(new MessageAction(battleResult.afterAttack.message1));
        }
        if (battleResult.afterAttack.message2 != null) {
            actionList.Add(new MessageAction(battleResult.afterAttack.message1));
        }

        if (battleResult.endTheBattle.message1 != null) {
            actionList.Add(new MessageAction(battleResult.endTheBattle.message1));
        }
        if (battleResult.endTheBattle.message2 != null) {
            actionList.Add(new MessageAction(battleResult.endTheBattle.message1));
        }

        return actionList;
    }
}
