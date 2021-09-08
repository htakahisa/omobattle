using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Charactor : MonoBehaviour
{

    private int orgHp;
    private int orgKougeki;
    private int orgSpeed;
    private int hp;
    private int kougeki;
    private int speed;
    private List<JumonType> jumonTypeList;
    private string name;
    private Type type = Type.NON;
    private ItemType itemType = ItemType.NON;
    private JumonType jumonTypeKodawari = JumonType.NON;
    private Boolean isKodawari;

    private int daimaxTurn = 0;

    private float level = 0;


    public void setIsKodawari(Boolean kodawari) {
        this.isKodawari = kodawari;
    }
    public Boolean getIsKodawari() {
        return this.isKodawari;
    }

    public Charactor setLevel(float level) {
        this.level = level;
        return this;
    }
    public void setDaimaxTurn(int daimaxTurn) {
        this.daimaxTurn = daimaxTurn;
    }
    public bool minusDaimaxTurn() {
        this.daimaxTurn -= 1;
        return this.daimaxTurn == 0;
    }
    
    private int getDaimaxHpRate() {
        if (this.daimaxTurn > 0) {
            return 2;
        } else {
            return 1;
        }
    }
    private float getDaimaxKougekiRate() {
        if (this.daimaxTurn > 0) {
            return 1.3f;
        } else {
            return 1;
        }
    }

    private float getLeveleRate() {
        return level * 0.01f + 1;
    }

    public int getHp() {
        return (int) (this.hp * this.getDaimaxHpRate() * this.getLeveleRate());
    }

    public float getHpParcentage() {
        return (float)getHp() / (float)this.getMaxHp();
    }
    public string getName() {
        return this.name;
    }
    public void plusHp(int hp) {
        this.hp += hp;
        if (this.hp > this.orgHp) {
            this.hp = this.orgHp;
        }
    }
    public int getKougeki() {

        float kodawari = 1f;
        if (ItemType.KODAWARIHATIMAKI == itemType) {
            kodawari = 2f;
        }

        if (this.kougeki > this.orgKougeki * 4) {
            return Mathf.FloorToInt((float)this.orgKougeki * 4 * this.getDaimaxKougekiRate() * this.getLeveleRate() * kodawari);
        } else {
            return Mathf.FloorToInt((float)this.kougeki * this.getDaimaxKougekiRate() * this.getLeveleRate() * kodawari);
        }
        
    }
    public void plusKougeki(int kougeki) {
        this.kougeki += kougeki;
    }
    public int getSpeed() {

        float kodawari = 1f;
        if (ItemType.KODAWARISUKAFU == itemType) {
            kodawari = 1.5f;
        }

            return Mathf.FloorToInt(this.speed * kodawari);
    }
    public void plusSpeed(int speed) {

        this.speed += speed;
    }

    public ItemType getItemType() {
        return this.itemType;
    }

    public JumonType getJumonTypeKodawari() {
        return this.jumonTypeKodawari;
    }
    public void setJumonTypeKodawari(JumonType jumonType) {
        this.jumonTypeKodawari = jumonType;
    }

    public void init(int hp, int kougeki, int speed, List<JumonType> jumonTypeList, string name) {
        this.orgHp = hp;
        this.orgKougeki = kougeki;
        this.orgSpeed = speed;
        this.hp = hp;
        this.kougeki = kougeki;
        this.speed = speed;
        this.jumonTypeList = jumonTypeList;
        this.name = name;
        this.type = Type.HUTUU;
    }

    public void init(int hp, int kougeki, int speed, List<JumonType> jumonTypeList, string name, Type type) {
        this.orgHp = hp;
        this.orgKougeki = kougeki;
        this.orgSpeed = speed;
        this.hp = hp;
        this.kougeki = kougeki;
        this.speed = speed;
        this.jumonTypeList = jumonTypeList;
        this.name = name;
        this.type = type;
    }

    public Type getType() {
        return this.type;
    }

    public void setItemType(ItemType itemType) {
        this.itemType = itemType;
    }

    public List<JumonType> getJumonTypeList() {
        return this.jumonTypeList;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    virtual public bool damage(int damage) {

        return this.damage(damage, null);
     }

    virtual public bool damage(int damage, Action a) {

        if (ItemType.NON != itemType) {
            if (ItemType.KIAINOTASUKI == itemType) {

                if (this.hp - damage <= 0) {
                    msg("な、な、なんと!! " + name + " はきあいのタスキで持ちこたえた!");
                    this.hp = 1;
                    itemType = ItemType.NON;
                    return false;
                }

            }


        }

        if (a != null) {
            
            if (a.getJumonType() == JumonType.KYOUUN) {
                if (UnityEngine.Random.Range(0, 3) == 0) {

                    int msgRandom = UnityEngine.Random.Range(10, 18);
                    if (msgRandom == 10) {

                        msg("「ひーーー! 敵が強いよどうしよーーー!!」");
                        System.Threading.Tasks.Task.Delay(1500);
                        msg("その時! 空が光り巨大な宇宙船が現れ敵を連れ去ってしまった!");
                    } else if (msgRandom == 11) {

                        msg("「ひーーー! あかんであかんでーーー!!」");
                        System.Threading.Tasks.Task.Delay(1500);
                        msg("その時! 空があつい雲に覆われ、巨大な雷が相手に命中した! 敵を倒した!!");
                    } else if (msgRandom == 12) {

                        msg("「ひーーー! 誰か助けてーーー!!」");
                        System.Threading.Tasks.Task.Delay(1500);
                        msg("その時! 誰かが森の中から毒の弓矢を放ち相手の首に命中した! 敵は倒れた!!");
                    } else if (msgRandom == 13) {

                        msg("「ひーーー! もう逃げるでーーー!!」");
                        System.Threading.Tasks.Task.Delay(1500);
                        msg("その時! 足を木の根っこに引っ掛けて思いっきりずっこけて敵の頭にぶつかり敵が気絶した!! 敵は戦闘不能だ!");
                    } else if (msgRandom == 14) {

                        msg("「ひーーー! もう無理やでーーー!!」");
                        System.Threading.Tasks.Task.Delay(1500);
                        msg("その時! 空から1000個の隕石が降り注ぎ、すべて相手に命中した! 相手は吹っ飛んだ!!");
                    } else if (msgRandom == 15) {

                        msg("「ひーーー! 髪が生えたでーーー！");
                        System.Threading.Tasks.Task.Delay(1500);
                        msg("その時！海の水が濃度99%になり、相手はうっかり海の水を飲んでしまい倒れた！");
                    } else if (msgRandom == 16) {

                        msg("「ひーーー! 髪よ、お助けーーー！」");
                        System.Threading.Tasks.Task.Delay(1500);
                        msg("その時! 相手は隣のマンションの騒音で耳が聞こえなくなり、とうやまの降参の合図が聞こえず、反則負けした！");
                    } else if (msgRandom == 17) {

                        msg("「ひーーー!　テレビ録画しとけばよかったーーー！！」");
                        System.Threading.Tasks.Task.Delay(1500);
                        msg("その時! 相手は寝てしまい、とうやまの「スーパーハイパークラッシャー真」を食らい、倒れた！！");
                    }

                    hp = 0;
                    
                    return true;
                }
            }
        }



        this.hp -= (int) (damage / this.getDaimaxHpRate() / this.getLeveleRate());

        return this.hp <= 0;
    }

    public int getMaxHp() {
        return (int)( this.orgHp * getDaimaxHpRate() * this.getLeveleRate());
    }

    public int getKougekiPower(KougekiType k) {
        if (k == KougekiType.KOUGEKI) {

            float inochinoTama = 1.0f;
            if (ItemType.INOCHINOTAMA == itemType) {
                inochinoTama = 1.5f;
            }

            return Mathf.FloorToInt(kougeki * this.getDaimaxKougekiRate() * this.getLeveleRate() * inochinoTama);
        }

        return 0;
    }


    async virtual public void tuika() {

    }

    async virtual public void tuikaEnd() {

    }

    async virtual public System.Threading.Tasks.Task kougekimae(Action a) {

        if (a.getJumonType() == JumonType.YUBUWOHURU) {

            JumonType jumonType = a.getJumonType();
            for (; true;) { 
                jumonType = this.getRandomEnum<JumonType>();
                if (jumonType != JumonType.YUBUWOHURU) {
                    break;
                }
            }
            JumonTypeMapper jm = new JumonTypeMapper();

            //await this.msg(name + " の指を振る!");
            //await this.msg(jm.getName(jumonType) + " が出た!");

            GameObject.Find("ButtleMsgText").GetComponent<UnityEngine.UI.Text>().text = name + " の指を振る!";
            await System.Threading.Tasks.Task.Delay(1500);
            GameObject.Find("ButtleMsgText").GetComponent<UnityEngine.UI.Text>().text = jm.getName(jumonType) + " が出た!";
            await System.Threading.Tasks.Task.Delay(1500);

            a.setJumonType(jumonType);
            a.setKougekiType(jm.getKougekiType(jumonType));

        }


    }
    async virtual public System.Threading.Tasks.Task kougekiato(Action a) {

        JumonTypeMapper jm = new JumonTypeMapper();

        if (ItemType.INOCHINOTAMA == itemType && KougekiType.KOUGEKI == jm.getKougekiType(a.getJumonType())) {
            await msg(name + " はいのちが少し削られた!");
            
           damage(Mathf.FloorToInt(this.getMaxHp() * 0.1f), a);
        }



    }

    async virtual public System.Threading.Tasks.Task msg(string msg) {
        GameObject.Find("ButtleMsgText").GetComponent<UnityEngine.UI.Text>().text = msg;
        await System.Threading.Tasks.Task.Delay(1500);
    }


    public T getRandomEnum<T>() {
        System.Random random = new System.Random();  // 乱数

        return Enum.GetValues(typeof(T))
            .Cast<T>()
            .OrderBy(c => random.Next())
            .FirstOrDefault();
    }
}
