using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THBSimulate
{
    class Area<F> : ICollection<F>
    {
        public List<F> items = new();
        public int Count { get { return items.Count; } }

        public bool IsReadOnly => false;
        protected Player owner;
        public Area(Player player) { owner = player; }

        public F Pop(int index)
        {
            if (index >= items.Count) { throw new Exception("空对象！"); }
            F item = items[index];
            items.Remove(item);
            return item;
        }
        public F Pop()
        {
            if (items.Count <= 0) { throw new Exception("空对象！"); }
            return Pop(items.Count - 1);
        }
        public void Add(F item)
        {
            items.Insert(0, item);
        }
        public void Add(F[] items)
        {
            Array.Reverse(items);
            foreach (F item in items)
            {
                this.items.Insert(0, item);
            }
        }

        public void Clear()
        {
            items.Clear();
        }
        public bool Contains<T>()
        {
            foreach (var item in items) { if (item is T) { return true; } }
            return false;
        }
        public bool Contains<T>(out T t) where T : F
        {
            foreach (var item in items) { if (item is T t1) { t = t1; return true; } }
#pragma warning disable CS8601
            t = default;
#pragma warning restore CS8601
            return false;
        }

        public void CopyTo(F[] array, int arrayIndex)
        {
            items.CopyTo(array, arrayIndex);
        }

        public IEnumerator<F> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        public bool Remove(F item)
        {
            return items.Remove(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (items as IEnumerable).GetEnumerator();
        }

        bool ICollection<F>.Contains(F item)
        {
            throw new NotImplementedException();
        }
        public F this[int index]
        {
            get { return items[index]; }
            set { items[index] = value; }
        }
        public F? this[F some]
        {
            get
            {
                foreach (var item in items)
                {
                        if(item is F)
                            if (item.Equals(some)) { return item; }
                }
                return default;
            }
        }
    }
    class HandCardsArea : Area<Card>
    {
        public HandCardsArea(Player owner) : base(owner) { }
        public Card? FirstPlayableCard
        {
            get
            {
                foreach (var card in items)
                {
                    if (card.strategy == CardStrategy.Positive)
                    {
                        if (card is Attack)
                        {
                            if (owner.handCardsArea.Contains(out Wine wine) && !owner.state.Contains(State.Drunked)) return wine;//如果有酒的话，先出酒再出弹幕
                            if (owner.strength > 0) return card;
                        }
                        else if (card is Heal)
                        {
                            if (owner.Hp < owner.character.maxHp) return card;
                        }
                        else if (card is Wine)
                        {
                            if (owner.handCardsArea.Contains<Attack>() && !owner.state.Contains(State.Drunked)) return card;//没有弹幕的话不出酒
                        }

                    }
                }
                return null;
            }
        }
    }
    class EquipmentArea : Area<EquipmentCard>
    {
        public EquipmentArea(Player owner) : base(owner) { }
    }
    class JudgeArea : Area<SkillCard>
    {
        public JudgeArea(Player owner) : base(owner) { }
    }
    class SkillArea : Area<Skill>
    {
        public SkillArea(Player owner) : base(owner) { }
        new public void Add(Skill skill)
        {
            skill.owener = owner;
            skill.Init(owner);
            items.Add(skill);
        }
        new public void Add(Skill[] skills)
        {
            foreach (var skill in skills) { skill.owener = owner; ; skill.Init(owner); }
            items.AddRange(skills);
        }
    }
}
