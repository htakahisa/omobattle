using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public enum JumonType
{
    KAMITUKU, // 噛みつく
    TAIATARI, // 体当たり
    WARAWASERU, // 笑わせる
    PANTI, // パンチ
    KYOUUN, // 強運
    ANKOKUU, // 暗黒に紛れて倒す
    KYUUKETU, // 吸血
    KESU, // 消す
    DANRYOKU, // 弾力
    RYUNOIBUKI, // 竜の息吹
    DORAGONSTAR, // ドラゴンスター
    BIMU, // ビーム
    KODAIHEIKI, // 古代兵器
    HOWAITOSIRU, // ホワイトシル
    BURAKKUZADO, // ブラックザード
    SOUZOU, // 創造
    HAKAI, // 破壊
    HOUKIDETOBU, // ほうきで飛ぶ
    ABURAKATABURA,　//　アブラカタブラ
    KIERU,　//　消える
    IKAZUTI,　//　雷
    BEASUTORAIKU,  //　ベアストライク
    BEAATAKKU,  //　ベアアタック
    HIKKAKU,  //　引っ掻く
    MITIZURE,  //　道ずれ
    SINIGAMINOKAMA,  //　死神の鎌
    HOWAKKUSIZA,  //　ホワックシザ
    SOUZOUSOSITEHAKAI,  //　創造そして破壊
    DORAGONASUKU,  //　ドラゴンアスク
    HANEYASUME,  //　はねやすめ
    KAMINOKAMI,  //　神の髪
    DENSETUNOIKAZUTI,  //　伝説の雷
    DENSETUNOSINIGAMINOKAMA,  //　神の髪
    HOWAKKUZUTI,  //　ホワックズチ
    SOUZOUSOSITEHAKAISOSITEIKAZUTI,  //　創造そして破壊そして雷
    HAGE, //　はげ
    SOUZOUSOSITEHAKAISOSITEIKAZUTIEX,  //　創造そして破壊そして雷そして誰もいなくなった
    HOWAKKUZUTIEX,  //　ホワックズチEX
    TOMATOTANSAKI,　//　トマト探査機
    TABERU,　//　食べる
    OMOIIPPATU,　//　重い一発
    KENWOHURIMAWASU,　//　剣を振り回す
    KAGEUTI,　//　影うち
    ANSINSISUTEMU,　//　安心システム
    ZISIN,　//　地震
    DAIKONWONUKU,　// 大根を抜く
    TABERARERU,　//　食べられる
    SIZENKAIHUKU,　//　自然回復
    HURENDO,　//　フレンド
    HIKARU,　//　光る
    PAINAPPURU, //　パイナップル
    KOSYOU,　// 故障
    FAIYAZAREKUSSU, //　ファイヤー・ザ・レックス
    EIRIANSUTORAIKU,　//　エイリアンストライク
    PURIZUMASAFAIA,　//　プリズマサファイア
    BURIRIANTOKAKUTERU,　// ブリリアントカクテル
    FAIYAZAREKUSSUex, //　ファイヤー・ザ・レックスex
    EIRIANSUTORAIKUex,　//　エイリアンストライクex
    PURIZUMASAFAIAex,　//　プリズマサファイアex
    BURIRIANTOKAKUTERUex,　// ブリリアントカクテルex
    KYOURANSYOKUZI,　//　狂乱食事
    BOUHUU,　//　暴風
    HOROBI, //　滅び
    HORORORO, // ホロロロ
    SECRETTHEPERFECT, //　シークレット・ザ・パーフェクト


    UZA,　//　うざ
    AORI,　// 煽り
    ATAIRU, // 攻撃アップ
    KURION, // HP回復
    SPAMD, // スピードアップ
    GOUN, // 攻撃2段階アップ
    GOUGOGOUN, // 攻撃６段階アップ
    KUBIWONAGAKUSURU, // 首を長くする
    APPUDETO, // アプデ
    DOUSIYO, // どうしよ
    GATIDEDOUSIYO, // ガチでどうしよ
    GOUGOUGOUGOGOUN, // ゴウゴウゴウゴゴウン
    TENBATU, // 天罰
    KAMIWONAGAKUSURU, // 髪を長くする
    OIKAZE, // 追い風
    YUBUWOHURU, // 指を振る
    RUGAN, //ルガン

    CHANGE, // 交代
    NON
}

public class JumonTypeMapper {

    private Dictionary<JumonType, JumonInfo> dic = new Dictionary<JumonType, JumonInfo>();


    public JumonTypeMapper() {
        dic.Add(JumonType.KAMITUKU, new JumonInfo(3180, KougekiType.KOUGEKI, Type.AKU, 0, "噛みつく", "思いっきり噛みついた!"));
        dic.Add(JumonType.TAIATARI, new JumonInfo(2100, KougekiType.KOUGEKI, Type.HUTUU, 0, "体当たり", "体当たりして敵はぶつかった衝撃で倒れた!"));
        dic.Add(JumonType.WARAWASERU, new JumonInfo(3080, KougekiType.KOUGEKI, Type.DENKI, 0, "笑わせる", "超絶面白いことを言って相手が大爆笑して腹がよじれた!"));
        dic.Add(JumonType.PANTI, new JumonInfo(2110, KougekiType.KOUGEKI, Type.HUTUU, 0, "パンチ", "パンチで攻撃した!"));
        dic.Add(JumonType.ANKOKUU, new JumonInfo(3080, KougekiType.KOUGEKI, Type.AKU, 0, "アンコクウ", "暗黒に紛れた!"));
        dic.Add(JumonType.KUBIWONAGAKUSURU, new JumonInfo(-100, KougekiType.KOUGEKI, Type.HUTUU, 0, "首を長くする", "首が長すぎる―!"));
        dic.Add(JumonType.KYOUUN, new JumonInfo(4920, KougekiType.KOUGEKI, Type.HIKARI, 3, "強運", "ポケットから忘れていたお菓子が出てきた!\n投げつけたら相手の目に当たった!"));
        dic.Add(JumonType.GATIDEDOUSIYO, new JumonInfo(3000, KougekiType.KOUGEKI, Type.HUTUU, 0, "ガチでどうしよう", "ガチでどうしよう!ガチでどうしよう!\nガチで焦って前が見えなくなり相手にすごい勢いでぶつかった!"));
        dic.Add(JumonType.TENBATU, new JumonInfo(3600, KougekiType.KOUGEKI, Type.HIKARI, 0, "天罰", "天罰!\n相手は反省した！"));
        dic.Add(JumonType.KYUUKETU, new JumonInfo(4030, KougekiType.KOUGEKI, Type.AKU, 0, "吸血", "相手の血を吸った！"));
        dic.Add(JumonType.KESU, new JumonInfo(3370, KougekiType.KOUGEKI, Type.HUTUU, 0, "消す", "相手は消えた！"));
        dic.Add(JumonType.DANRYOKU, new JumonInfo(1900, KougekiType.KOUGEKI, Type.HUTUU, 0, "弾力", "デコピンしてきた相手をゴムの弾力でカウンターした！！"));
        dic.Add(JumonType.RYUNOIBUKI, new JumonInfo(4580, KougekiType.KOUGEKI, Type.AKU, 0, "竜の息吹", "強烈な炎を吐いた!"));
        dic.Add(JumonType.DORAGONSTAR, new JumonInfo(3000, KougekiType.KOUGEKI, Type.AKU, 1, "ドラゴンスター", "流星のスピードで攻撃した!"));
        dic.Add(JumonType.KODAIHEIKI, new JumonInfo(3300, KougekiType.KOUGEKI, Type.DENKI, 0, "古代兵器", "よみがえる伝説!"));
        dic.Add(JumonType.BIMU, new JumonInfo(2830, KougekiType.KOUGEKI, Type.DENKI, 0, "ビーム", "レーーーザ―――ビーーーム!"));
        dic.Add(JumonType.HOWAITOSIRU, new JumonInfo(3530, KougekiType.KOUGEKI, Type.HIKARI, 0, "ホワイトシル", "聖の攻撃!"));
        dic.Add(JumonType.BURAKKUZADO, new JumonInfo(3530, KougekiType.KOUGEKI, Type.AKU, 0, "ブラックザード", "悪の攻撃!"));
        dic.Add(JumonType.SOUZOU, new JumonInfo(4730, KougekiType.KOUGEKI, Type.HIKARI, 0, "創造", "創造神が創る！正義の神!"));
        dic.Add(JumonType.HAKAI, new JumonInfo(4730, KougekiType.KOUGEKI, Type.AKU, 0, "破壊", "破壊神が壊す!悪の神"));
        dic.Add(JumonType.ABURAKATABURA, new JumonInfo(3030, KougekiType.KOUGEKI, Type.HUTUU, 0, "アブラカタブラ", "アブラカタブラホニャニャカホイ"));
        dic.Add(JumonType.IKAZUTI, new JumonInfo(3530, KougekiType.KOUGEKI, Type.DENKI, 0, "雷", "相手に雷が落ちて大ダメージ！"));
        dic.Add(JumonType.BEASUTORAIKU, new JumonInfo(4130, KougekiType.KOUGEKI, Type.HUTUU, 0, "ベアストライク", "クマのような攻撃力！切り裂く―！"));
        dic.Add(JumonType.BEAATAKKU, new JumonInfo(3730, KougekiType.KOUGEKI, Type.HUTUU, 0, "ベアアタック", "クマのように切り裂く！"));
        dic.Add(JumonType.HIKKAKU, new JumonInfo(2430, KougekiType.KOUGEKI, Type.HUTUU, 0, "引っ掻く", "切り裂いて相手に傷ができた！！"));
        dic.Add(JumonType.SINIGAMINOKAMA, new JumonInfo(3030, KougekiType.KOUGEKI, Type.AKU, 0, "死神の鎌", "死神の鎌で相手の魂を奪う！"));
        dic.Add(JumonType.MITIZURE, new JumonInfo(2030, KougekiType.KOUGEKI, Type.AKU, 0, "道ずれ", "相手は道ずれにされた！"));
        dic.Add(JumonType.HOWAKKUSIZA, new JumonInfo(3330, KougekiType.KOUGEKI, Type.HONOO, 0, "ホワックシザ", "余談だけど創造 + 破壊 = 疎開って全然いみちげーな！ だ★か★ら？"));
        dic.Add(JumonType.SOUZOUSOSITEHAKAI, new JumonInfo(4400, KougekiType.KOUGEKI, Type.HONOO, 0, "創造そして破壊", "相手はもの凄いパワーでダメージを受けた"));
        dic.Add(JumonType.DORAGONASUKU, new JumonInfo(3530, KougekiType.KOUGEKI, Type.AKU, 0, "ドラゴンアスク", "  わー！"));
        dic.Add(JumonType.DENSETUNOIKAZUTI, new JumonInfo(5000, KougekiType.KOUGEKI, Type.DENSETU, 0, "伝説の雷", " 相手は伝説の雷をくらった！「神の力は最強なのだ！行け！ちなみにまだ50%くらいしか力出してないよ\n\n\n\nby神様"));
        dic.Add(JumonType.KAMINOKAMI, new JumonInfo(4030, KougekiType.KOUGEKI, Type.DENSETU, 0, "神の髪", " 神の髪は武器として使える！"));
        dic.Add(JumonType.DENSETUNOSINIGAMINOKAMA, new JumonInfo(10000000, KougekiType.KOUGEKI, Type.AKU, 0, "伝説の死神の鎌", " 伝説の死神の鎌が相手の魂を奪い、相手は大ダメージ！"));
        dic.Add(JumonType.SOUZOUSOSITEHAKAISOSITEIKAZUTI, new JumonInfo(8080, KougekiType.KOUGEKI, Type.HONOO, 0, "創造そして破壊そして雷", "相手はもの凄いパワーでダメージを受けたあとに雷を受けてとにかくやばい！"));
        dic.Add(JumonType.HOWAKKUZUTI, new JumonInfo(4730, KougekiType.KOUGEKI, Type.HONOO, 0, "ホワックズチ", " 神様とフェンシルとアクザードの三位一体だー！"));
        dic.Add(JumonType.HAGE, new JumonInfo(7831, KougekiType.KOUGEKI, Type.HIKARI, 0, "はげ！", " はげ代表とうやまの髪無し最強頭突き！髪がないことによりほかの人より３．５倍威力が高い！！ちなみに神様の技より威力高いらしいよ。(嘘）（3831）"));
        dic.Add(JumonType.SOUZOUSOSITEHAKAISOSITEIKAZUTIEX, new JumonInfo(3829, KougekiType.KOUGEKI, Type.HONOO, 0, "創造そして破壊そして雷EX", "相手はもの凄いパワーでダメージを受けたあとに雷の進化バージョンでとにかくやばい！"));
        dic.Add(JumonType.HOWAKKUZUTIEX, new JumonInfo(4530, KougekiType.KOUGEKI, Type.HIKARI, 0, "ホワックズチEX", " 神様とフェンシルとアクザードの三位一体だー！EX"));
        dic.Add(JumonType.TOMATOTANSAKI, new JumonInfo(4700, KougekiType.KOUGEKI, Type.DENKI, 0, "トマト探査機", "トマトを探していたらトマトを食べていた相手がトマトを発見した時のピー！ピー！という音で気絶した！"));
        dic.Add(JumonType.TABERU, new JumonInfo(3330, KougekiType.KOUGEKI, Type.AKU, 0, "食べる", "相手を食べた！相手は三分の一がなくなった！"));
        dic.Add(JumonType.OMOIIPPATU, new JumonInfo(5830, KougekiType.KOUGEKI, Type.AKU, -1, "重い一発", "  重い一発を食らい、大ダメージ！！"));
        dic.Add(JumonType.KENWOHURIMAWASU, new JumonInfo(3530, KougekiType.KOUGEKI, Type.AKU, 0, "剣を振り回す", "  カミ○ルギのように剣を振り回す！！"));
        dic.Add(JumonType.KAGEUTI, new JumonInfo(3000, KougekiType.KOUGEKI, Type.AKU, 2, "影うち", "  相手の背後に回って影うち！相手はいきなり後ろから攻撃されってびっくり！！"));
        dic.Add(JumonType.ANSINSISUTEMU, new JumonInfo(3630, KougekiType.KOUGEKI, Type.DENKI, 0, "安心システム", "  安心システムに引っかかった泥棒が逃げた先にいた相手は泥棒にぶつかって倒れた！"));
        dic.Add(JumonType.ZISIN, new JumonInfo(3930, KougekiType.KOUGEKI, Type.ZIMEN, 0, "地震", "  地震で揺れて相手は転んだ！"));
        dic.Add(JumonType.DAIKONWONUKU, new JumonInfo(3930, KougekiType.KOUGEKI, Type.ZIMEN, 0, "大根を抜く", "  抜いてる間に地震で揺れて相手は転んだ！"));
        dic.Add(JumonType.TABERARERU, new JumonInfo(3930, KougekiType.KOUGEKI, Type.ZIMEN, 0, "食べられる", "  食べられる代わりにおなかの中から攻撃！丸呑みしたのがあだとなったな！！"));
        dic.Add(JumonType.HURENDO, new JumonInfo(3930, KougekiType.KOUGEKI, Type.ZIMEN, 0, "フレンド", "  友達の、株・ニンジン・レンコン・バナナ（急に果物）を連れてきて、相手に総攻撃！（食べ物なので攻撃力は低い！）"));
        dic.Add(JumonType.HIKARU, new JumonInfo(3530, KougekiType.KOUGEKI, Type.HIKARI, 0, "光る", "  相手はまぶしすぎて目が開けられない！まるでとうやまの頭！"));
        dic.Add(JumonType.PAINAPPURU, new JumonInfo(2530, KougekiType.KOUGEKI, Type.HUTUU, 1, "パイナップル", "  パイナップルだから攻撃が低いぞー！(正先生攻撃)"));
        dic.Add(JumonType.KOSYOU, new JumonInfo(8030, KougekiType.KOUGEKI, Type.HONOO, 0, "故障", "  故障して大爆発！相手に超絶極神ダメージ！しかし自分も食らう！！"));
        dic.Add(JumonType.BURIRIANTOKAKUTERU, new JumonInfo(4530, KougekiType.KOUGEKI, Type.ZIMEN, 1, "ブリリアントカクテル", "  凍った相手は、        動けない"));
        dic.Add(JumonType.EIRIANSUTORAIKU, new JumonInfo(4330, KougekiType.KOUGEKI, Type.HIKARI, 2, "エイリアンストライク", "  相手はエイリアンがものすごいスピードで突っ込んできた衝撃で気絶した"));
        dic.Add(JumonType.PURIZUMASAFAIA, new JumonInfo(4900, KougekiType.KOUGEKI, Type.DENKI, 0, "プリズマサファイア", "  冷静に考えて電気技の威力4900は犯罪"));
        dic.Add(JumonType.BURIRIANTOKAKUTERUex, new JumonInfo(5030, KougekiType.KOUGEKI, Type.ZIMEN, 1, "ブリリアントカクテルex", "  凍った相手は、        動けない"));
        dic.Add(JumonType.EIRIANSUTORAIKUex, new JumonInfo(4830, KougekiType.KOUGEKI, Type.HIKARI, 2, "エイリアンストライクex", "  相手はエイリアンがものすごいスピードで突っ込んできた衝撃で気絶した"));
        dic.Add(JumonType.PURIZUMASAFAIAex, new JumonInfo(5300, KougekiType.KOUGEKI, Type.DENKI, 0, "プリズマサファイアex", "  冷静に考えて電気技の威力5300は犯罪"));
        dic.Add(JumonType.KYOURANSYOKUZI, new JumonInfo(4730, KougekiType.KOUGEKI, Type.AKU, 0, "狂乱食事", " 食事すらも狂っている！！"));
        dic.Add(JumonType.BOUHUU, new JumonInfo(7500, KougekiType.KOUGEKI, Type.HIKOU, 0, "暴風", "相手は暴風により吹き飛ばされた！"));
        dic.Add(JumonType.HOROBI, new JumonInfo(999999, KougekiType.KOUGEKI, Type.AKU, 0, "滅び", "3wefiuw98erd8uhweusfducjewusdfoduwe4w:fl4ptw4;f.,ge:t;.fg;@psokrpoeas90wor40-rofl:w;fpr@w;flsce@sprlfp@wpslfop@psd;lo@phdfcwqiaushd87weiusyfch"));
        dic.Add(JumonType.HORORORO, new JumonInfo(999999, KougekiType.KOUGEKI, Type.AKU, 0, "ホロロロ", " 地球ごと焼き尽くして、自分と相手に爆発的なダメージを与えた！！"));
        dic.Add(JumonType.SECRETTHEPERFECT, new JumonInfo(9000, KougekiType.KOUGEKI, Type.DENSETU, 0, "シークレット・ザ・パーフェクト", " ヴァリオンは、力を解禁し、パーフェクトになった！"));

        dic.Add(JumonType.FAIYAZAREKUSSU, new JumonInfo(2, KougekiType.KOUGEKI_UP, Type.HONOO, 0, "ファイヤーザレックス", "  炎をあえて自分にあてて燃え上がり、王の舞をして攻撃力を爆上げ！"));
        dic.Add(JumonType.FAIYAZAREKUSSUex, new JumonInfo(2.5f, KougekiType.KOUGEKI_UP, Type.HONOO, 0, "ファイヤーザレックスex", "  炎をあえて自分にあてて燃え上がり、王の舞をして攻撃力を爆上げ！しかもexだからたぶん何かしら変化があると思われる"));
        dic.Add(JumonType.SIZENKAIHUKU, new JumonInfo(0.5f, KougekiType.HP_UP, Type.ZIMEN, 0, "自然回復", "  少しの傷なら自然と復活！！"));
        dic.Add(JumonType.AORI, new JumonInfo(1.5f, KougekiType.KOUGEKI_UP, Type.AKU, 0, "煽り", "  うざすぎて相手全体が怒って防御が下がった！"));
        dic.Add(JumonType.UZA, new JumonInfo(1.5f, KougekiType.KOUGEKI_UP, Type.AKU, 0, "うざ", "  うざすぎて相手全体が怒って防御が下がった！"));
        dic.Add(JumonType.ATAIRU, new JumonInfo(1.3f, KougekiType.KOUGEKI_UP, Type.HUTUU, 0, "アタイル", "攻撃が上がった!今怖いものはない！"));
        dic.Add(JumonType.KURION, new JumonInfo(0.5f, KougekiType.HP_UP, Type.HUTUU, 0, "クリオン", "傷が治った!痛くなくなった！"));
        dic.Add(JumonType.SPAMD, new JumonInfo(444.4f, KougekiType.SPEED_UP, Type.HUTUU, 0, "スパリオン", "素早さにバフをかけろ！素早さが上がった!"));
        dic.Add(JumonType.GOUN, new JumonInfo(1.5f, KougekiType.KOUGEKI_UP, Type.HUTUU, 0, "ゴウン", "攻撃がぐーんと上がった!攻撃力がだいぶ上がったから勝てそうだ！"));
        dic.Add(JumonType.GOUGOGOUN, new JumonInfo(1.8f, KougekiType.KOUGEKI_UP, Type.HUTUU, 0, "轟檎雲", "攻撃が劇的に上がった!攻撃の頂点だ！次のターンで決める！"));
        dic.Add(JumonType.APPUDETO, new JumonInfo(9, KougekiType.SPEED_UP, Type.HUTUU, 0, "アップデート", "バージョン2.0になって進化した!キャラクターが増えて機能も増えてバランス調整も来て面白くなったぞ！"));
        dic.Add(JumonType.DOUSIYO, new JumonInfo(4.7f, KougekiType.SPEED_UP, Type.HUTUU, 0, "どうしよう", "どうしよう!どうしよう!\n焦って足が速くなった! 火事場のばか力！　とはちょっと違う"));
        dic.Add(JumonType.GOUGOUGOUGOGOUN, new JumonInfo(2, KougekiType.KOUGEKI_UP, Type.HUTUU, 0, "豪語羽後羽五五蘊", "豪語羽後羽五五蘊で攻撃がお化けだ！！"));
        dic.Add(JumonType.KAMIWONAGAKUSURU, new JumonInfo(3.8f, KougekiType.SPEED_UP, Type.HUTUU, 0, "髪を長くする", "髪が長すぎる！"));
        dic.Add(JumonType.YUBUWOHURU, new JumonInfo(0, KougekiType.NON, Type.HUTUU, 0, "指を振る", "")); // メッセージなどは Charactor で変更している
        dic.Add(JumonType.OIKAZE, new JumonInfo(10f, KougekiType.SPEED_UP, Type.HUTUU, 0, "追い風", "追い風でスピードアップ！！風も仲間だ！"));
        dic.Add(JumonType.HOUKIDETOBU, new JumonInfo(3.5f, KougekiType.SPEED_UP, Type.HUTUU, 0, "ほうきで飛ぶ", "ほうきに乗ることでスピードがアップ！！"));
        dic.Add(JumonType.KIERU, new JumonInfo(0.7f, KougekiType.HP_UP, Type.HUTUU, 0, "消える", "消えて隠れている間にクオリンで回復!まだ場所はばれていないぞ！"));
        dic.Add(JumonType.HANEYASUME, new JumonInfo(0.5f, KougekiType.HP_UP, Type.HUTUU, 0, "はねやすめ", "羽が休んで体力がup！！"));
        dic.Add(JumonType.RUGAN, new JumonInfo(2.8f, KougekiType.KOUGEKI_UP, Type.HUTUU, 0, "ルガン", "上から雷を落として、自分にあてることで、攻撃を極限まで高めた！！"));



        dic.Add(JumonType.CHANGE, new JumonInfo(1.5f, KougekiType.CHANGE, Type.HUTUU, 5, "交代だ!", ""));
        dic.Add(JumonType.NON, new JumonInfo(0, KougekiType.CHANGE, Type.HUTUU, 0, "何もしない", ""));
    }

    public int getPriolity(JumonType j) {
        return dic[j].getPriolity();
    }

    public string getMsg(JumonType j) {
        return dic[j].getMsg();
    }
    public string getName(JumonType j) {
        return dic[j].getName();
    }

    public int getValInt(JumonType j) {
        return Mathf.FloorToInt(dic[j].getVal());
    }
    public float getValFloat(JumonType j) {
        return dic[j].getVal();
    }
    public KougekiType getKougekiType(JumonType j) {
        return dic[j].getKougekiType();
    }

    public Type getType(JumonType j) {
        return dic[j].getType();
    }
}



public class JumonInfo {
    private float val = 0;
    private string name;
    private string msg;
    private KougekiType kougekiType;
    private Type type;
    private int priolity;

    public int getPriolity() {
        return this.priolity;

    }

    public Type getType() {
        return this.type;
    }

    public string getMsg() {
        return this.msg;
    }

    public float getVal() {
        return this.val;
    }
    public string getName() {
        return this.name;
    }
    public KougekiType getKougekiType() {
        return this.kougekiType;
    }


    public JumonInfo(float val, KougekiType kougekiType, Type type, int priolity, string name, string msg) {
        this.kougekiType = kougekiType;
        this.type = type;
        this.priolity = priolity;
        this.val = val;
        this.name = name;
        this.msg = msg;

    }
}

    