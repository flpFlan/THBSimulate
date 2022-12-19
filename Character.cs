using THBSimulate;

namespace THBSimulate
{
    enum SkillStrategy { Positive,Passive,None}
   abstract class BaseCharacter
    {
        public readonly string name;
        public byte maxHp;
        public List<Skill> skills = new();
        public BaseCharacter(string name,byte maxHp, List<Skill> skills)
        {
            this.name = name;
            this.maxHp = maxHp;
            this.skills=skills;
        }
    }
    class BaiBan : BaseCharacter
    {
        public BaiBan(string name, byte maxHp,List<Skill>skills) : base(name, maxHp,skills)
        {
        }
        public BaiBan() : base("白板", 4,new List<Skill>()) { }
    }
    class LittleDemon : BaseCharacter
    {
        public LittleDemon() : base("小恶魔", 4, new List<Skill>() { new Search()})
        {
        }
    }
    class Youmu : BaseCharacter
    {
        public Youmu() : base("妖梦", 4, new List<Skill>() { new CihangChop() })
        {
        }
    }
    abstract class Skill
    {
       public string name;
       public SkillStrategy strategy;
       public Player owener;
#pragma warning disable CS8618
        public Skill(string name,SkillStrategy skillStrategy) { this.name = name; this.strategy = skillStrategy; }
#pragma warning restore CS8618
        abstract public void Init(Player owenr);
        abstract public void Release(Player owenr);

    }
    abstract class PositiveSkill : Skill
    {
        protected PositiveSkill(string name) : base(name, SkillStrategy.Positive)
        {
        }
        public abstract void Use(Player taget);
    }
    abstract class PassiveSkill : Skill
    {
        protected PassiveSkill(string name) : base(name, SkillStrategy.Passive)
        {
        }
    }
    class Search : PositiveSkill
    {
        public Search() : base("寻找") { }

        public override void Init(Player owenr)
        {
            
        }

        public override void Release(Player owenr)
        {
            
        }

        public override void Use(Player taget)
        {
            search();
        }

        private void search()
        {
            owener.ExecuteSkill(this);
            int count = owener.handCardsArea.Count;
            owener.Discard(count);
            owener.Draw(GameManager.Instance.Scene.stackManager.Draw(count));
        }
    }
    class CihangChop : PassiveSkill
    {
        public CihangChop() : base("迷津慈航斩")
        {
        }

        public override void Init(Player owenr)
        {
            owenr.PlayCard += Chop;
        }

        public override void Release(Player owenr)
        {
            throw new NotImplementedException();
        }
        void Chop(Card card,Player target)
        {
            
            if(card is Attack)
            {
                owener.ExecuteSkill(this);
#pragma warning disable CS8602
                card.OnUse += _ => { (card as Attack).NeedCount += 1; };
                card.AfterUse += _ => { (card as Attack).NeedCount -= 1; };
#pragma warning restore CS8602
            }
        }
    }
}
