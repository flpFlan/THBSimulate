using THBSimulate;

namespace THBSimulate
{
    enum CardStrategy { Positive,Passive,None}
    interface IDamageCard
    {
        public byte Damage { get; set; }
    }
    interface IFeedBackAbleCard
    {
       public byte NeedCount { get; set; }
    }
    abstract class Card
    {
        public string Name { get; protected set; }
        public byte Point { get; protected set; }
        public Mark Mark { get; protected set; }
        public CardStrategy strategy;
        public CardClass cardClass;
        public event Action<Card> OnUse = _ => { };
        public event Action<Card> AfterUse = _ => { };
        protected Card(string name, byte point, Mark mark, CardClass cardClass, CardStrategy cardStrategy)
        {
            this.Name = name;
            this.Point = point;
            this.Mark = mark;
            this.cardClass = cardClass;
            this.strategy = cardStrategy;
        }
        /// <summary>
        /// 对目标玩家使用卡牌。
        /// </summary>
        /// <param name="source">使用卡牌的源对象。</param>
        /// <param name="target">使用卡牌的目标对象。</param>
        public void Use(Player source, Player target) { OnUse(this); Effect(source, target); AfterUse(this); }
        abstract protected void Effect(Player source, Player target);
}
    enum Mark { Heart, Diamond , Spade , Club,None }
    enum CardClass { Basic,Equipment,Skill,None}
}
class EmptyCard : Card
{
    public EmptyCard(string name, byte point, Mark mark) : base(name, point, mark,CardClass.None,CardStrategy.None)
    {
    }
    public EmptyCard() : this("EmptyCard",0,Mark.None) { }


    protected override void Effect(Player source, Player target)
    {
        throw new NotImplementedException();
    }
}
abstract class BasicCard : Card
{
    protected BasicCard(string name, byte point, Mark mark, CardStrategy strategy) : base(name, point, mark,CardClass.Basic,strategy)
    {
        
    }
}
class Attack : BasicCard,IDamageCard,IFeedBackAbleCard
{
    public Attack(string name, byte point, Mark mark) : base(name, point, mark, CardStrategy.Positive)
    {
    }
    public Attack(byte point,Mark mark) : this("弹幕", point, mark) { }

    public byte Damage { get; set; } = 1;

    public byte NeedCount { get; set; } = 1;

    protected override void Effect(Player source, Player target)
    {
        byte damage = Damage;
        source.strength -= 1;
        byte _needCount = NeedCount;
        while (_needCount > 0)
        {
            if (target.handCardsArea.Contains(out Graze graze)) { target.Response(graze); _needCount-=1; if (_needCount == 0) { return; } }
            else { break; }
        }
        if (source.state.Contains(State.Drunked)) { source.state.Remove(State.Drunked);damage += 1; }
        target.GetDamage(source, damage);
    }
}
class Graze : BasicCard
{
    public Graze(string name, byte point, Mark mark) : base(name, point, mark, CardStrategy.Passive)
    {
        
    }
    public Graze(byte point, Mark mark) : this("擦弹", point, mark) { }

    protected override void Effect(Player source, Player target)
    {
        
    }
}
class Heal : BasicCard
{
    public byte heal = 1;
    public Heal(string name, byte point, Mark mark) : base(name, point, mark, CardStrategy.Positive)
    {
    }
    public Heal(byte point, Mark mark) : this("麻薯", point, mark) { }

    protected override void Effect(Player source, Player target)
    {
        target.GetHeal(heal);
    }
}
class Wine : BasicCard
{
    public Wine(string name, byte point, Mark mark) : base(name, point, mark,CardStrategy.Positive)
    {
    }
    public Wine(byte point, Mark mark) : base("酒", point, mark, CardStrategy.Positive)
    {
    }

    protected override void Effect(Player source, Player target)
    {
        target.state.Add(State.Drunked);
    }
}
abstract class EquipmentCard : Card
{
    protected EquipmentCard(string name, byte point, Mark mark, CardStrategy strategy) : base(name, point, mark, CardClass.Equipment, strategy)
    {

    }
    public EquipmentCard(string name, byte point, Mark mark) : base(name, point, mark, CardClass.Equipment, CardStrategy.Positive)
    {

    }
}
abstract class SkillCard : Card
{
    protected SkillCard(string name, byte point, Mark mark, CardStrategy strategy) : base(name, point, mark, CardClass.Skill, strategy)
    {

    }
    public SkillCard(string name, byte point, Mark mark) : base(name, point, mark, CardClass.Skill, CardStrategy.Positive)
    {

    }
}