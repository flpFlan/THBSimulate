using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THBSimulate;

namespace THBSimulate
{
    class GameManager
    {
        private static GameManager? instance;
      public static  GameManager Instance { get { instance ??= new GameManager(); return instance; } }
        Scene? _scene;
        public Scene Scene { get { _scene??= new Scene(); return _scene; } set { _scene = value; } }
       
        GameManager() { }
        
    }
    class CardsStackManager
    {
        readonly Random Rand = new();
        public List<Card> cardsStack = new();
        public List<Card> discardsStack = new();
        public event Action StackShuffled = () => { };
        public event Action<int> CardsStackChanged = _ => { };
        public event Action<int> DiscardsStackChanged = _ => { };
        public Card[] Draw(int num)
        {
            if (cardsStack.Count < num)
            {
                Shuffle();
            }
            Card[] cards = new Card[num];
            for(int i = 0; i < num; i++)
            {
                var card = cardsStack.First();
                cardsStack.RemoveAt(0);
                cards[i]=card;
            }
            CardsStackChanged(-num);
            if(cardsStack.Count == 0) { Shuffle(); }
            return cards;
        }
        public Card Draw()
        {
            return Draw(1)[0];
        }
        public void Discard(Card card)
        {
            discardsStack.Add(card);
            DiscardsStackChanged(1);
        }
        public void Discard(Card[] cards)
        {
            discardsStack.AddRange(cards);
            DiscardsStackChanged(cards.Length);
        }
        public void Disorder()
        {
            List<Card> lam_cards = new();
            foreach (var card in cardsStack) { lam_cards.Add(card); }
            cardsStack.Clear();
            foreach (var item in lam_cards)
            {
                cardsStack.Insert(Rand.Next(cardsStack.Count), item);
            }
        }
        public void Shuffle()
        {
            discardsStack.AddRange(cardsStack);
            cardsStack.Clear();
            foreach (var item in discardsStack)
            {
                cardsStack.Insert(Rand.Next(cardsStack.Count), item);
            }
            discardsStack.Clear();
            StackShuffled();
        }
        public Card Judge()
        {
            var card = Draw();
            Discard(card);
            return card;
        }
    }
}
/// <summary>
/// 表示游戏场景。
/// </summary>
class Scene
{
    public List<Player> players=new();
    Player? _hasToken;
    public Player HasToken { set { value.stage = Stage.Prepare; _hasToken = value; } get { _hasToken ??= players[0]; return _hasToken; } }
    public CardsStackManager stackManager = new();
    public Scene()
    {
        for (int i = 0; i < 144; i++)//生成牌堆
        {
            if (i < 72)
            {
                this.stackManager.cardsStack.Add(new Attack(0, Mark.None));
            }
            else if(i<112)
            {
                this.stackManager.cardsStack.Add(new Graze( 0, Mark.None));
            }
            else if(i<132)
            {
                this.stackManager.cardsStack.Add(new Heal(0, Mark.None));
            }
            else if (i < 144)
            {
                this.stackManager.cardsStack.Add(new Wine(0, Mark.None));
            }
        }
        this.stackManager.Disorder();
    }
    public bool IsGameEnds()
    {
        return players.Any(p => p.IsDead);  // 如果选择到IsDead的Player，游戏结束
    }
}

