using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THBSimulate
{
    enum State { Drunked, None }
    enum Stage { Prepare, Judge, Draw, Play, Discard, End, Wait }
    /// <summary>
    /// 表示游戏中的玩家。
    /// </summary>
    class Player
    {

        Random rand = new Random();
        public readonly int id;
        public string name { get { if (character.name != null) { return character.name; } return "P" + id.ToString(); } }
        public AI ai;
        public BaseCharacter character;
        public HandCardsArea handCardsArea;
        public JudgeArea judgesArea;
        public EquipmentArea equipmentsArea;
        public SkillArea skillArea;
        public HashSet<State> state;
        public Stage stage = Stage.Wait;
        public event Action<string> SendMessage = _ => { };
        public event Action<Skill> TriggerSkill = _ => { };
        public event Action<PositiveSkill, Player> UseSkill = (_, _) => { };
        public event Action<Player?, byte> OnGetDamage = (_, _) => { };
        public event Action<Player, byte> OnGetHeal = (_, _) => { };
        public event Action<int> OnDying = _ => { };
        public event Action Dead = () => { };
        public event Action<int> DrawCard = _ => { };
        public event Action<List<Card>> AfterDiscard = _ => { };
        public event Action<Card, Player> PlayCard = (_, _) => { };
        public event Action<Card> RespondCard = _ => { };
        public event Action StageStart = () => { };
        public event Action JudgeStart = () => { };
        public event Action DrawStart = () => { };
        public event Action PlayStart = () => { };
        public event Action DiscardStart = () => { };
        public event Action StageEnd = () => { };
        public int Hp;
        public byte strength = 1;
        public Card? FirstPlayableCard { get { return handCardsArea.FirstPlayableCard; } }
        public Player(int id, BaseCharacter character)
        {
            this.id = id;
            this.ai = new BaiBanAI(this);
            this.character = character;
            Hp = character.maxHp;
            handCardsArea = new HandCardsArea(this);
            judgesArea = new JudgeArea(this);
            equipmentsArea = new EquipmentArea(this);
            skillArea = new SkillArea(this);
            state = new HashSet<State>();
            UseSkill += (skill, player) => { skill.Use(player); };
        }
        public void TakeTurn()
        {
            switch (stage)
            {
                case Stage.Prepare:
                    {
                        StageStart();
                        ai.PrepareUpdate();
                        stage += 1;
                        break;
                    }
                case Stage.Judge:
                    {
                        JudgeStart();
                        ai.JudgeUpdate();
                        stage += 1;
                        break;
                    }
                case Stage.Draw:
                    {
                        DrawStart();
                        ai.DrawUpdate();
                        stage += 1;
                        break;
                    }
                case Stage.Play:
                    {
                        PlayStart();
                        ai.PlayUpdate();
                        stage += 1;
                        break;
                    }
                case Stage.Discard:
                    {
                        DiscardStart();
                        ai.DiscardUpdate();
                        stage += 1;
                        break;
                    }
                case Stage.End:
                    {
                        StageEnd();
                        ai.EndUpdate();
                        stage += 1;
                        break;
                    }
                default:
                    {
                        stage = Stage.Wait;
                        break;
                    }
            }
        }
        public void Play(Card card, Player target)
        {
            PlayCard(card, target);
            handCardsArea.Remove(card);
            GameManager.Instance.Scene.stackManager.Discard(card);
        }
        public void Play(Card card)
        {
            Play(card, this);
        }
        public void Response(Card card)
        {
            RespondCard(card);
            handCardsArea.Remove(card);
            GameManager.Instance.Scene.stackManager.Discard(card);
        }
        public bool IsDead
        {
            get { return Hp <= 0; }
        }


        public void Discard(int discardNum)
        {
            if (discardNum <= 0 || handCardsArea.Count == 0) return;
            List<Card> discards = new();
            for (int i = 0; i < discardNum; i++)
            {
                discards.Add(handCardsArea.Pop(rand.Next(handCardsArea.Count - 1)));
            }
            AfterDiscard(discards);
            GameManager.Instance.Scene.stackManager.Discard(discards.ToArray());
        }
        public void GetDamage(Player? source, byte damage)
        {
            OnGetDamage(source, damage);
            Hp -= damage;
            if (IsDead) { OnDying(1 - Hp); }
            if (IsDead) { Dead(); }
        }
        public void GetDamage(byte damage)
        {
            GetDamage(null, damage);
        }
        public void GetHeal(Player source, byte amount)
        {
            OnGetHeal(source, amount);
            Hp += amount;
        }
        public void GetHeal(byte amount)
        {
            GetHeal(this, amount);
        }
        public void Draw(Card[] cards)
        {
            DrawCard(cards.Length);
            handCardsArea.Add(cards);
        }
        public void Draw(Card card)
        {
            Draw(new Card[] { card });
        }
        public void ExecuteSkill(Skill skill)
        {
            TriggerSkill(skill);
        }
    }
}
