using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THBSimulate;

namespace THBSimulate
{
   abstract class AI 
    {
        protected Player own;
        public AI(Player own) { this.own = own; }
        public abstract void PrepareUpdate();
        public abstract void JudgeUpdate();
        public abstract void DrawUpdate();
        public abstract void PlayUpdate();
        public abstract void DiscardUpdate();
        public abstract void EndUpdate();
        public static AI BindAI(Player owner,string name)
        {
            return name switch
            {
                "小恶魔" => new LitteDemoAI(owner),
                "妖梦" => new YoumuAI(owner),
                "白板" => new BaiBanAI(owner),
                _ => throw new Exception("不存在的AI!")
            };
        }
    }
    abstract class ComputerAI : AI
    {
        protected ComputerAI(Player own) : base(own)
        {
        }
    }
    class BaiBanAI:ComputerAI
    {

        public BaiBanAI(Player own) : base(own)
        {
        }

        public override void PrepareUpdate()
            {
                GameManager.Instance.Scene.HasToken =own;
                own.strength = 1;
            }
           public override void JudgeUpdate()
            {
                if (own.judgesArea.Count <= 0) return;
            }
           public override void DrawUpdate()
            {
                own.Draw(GameManager.Instance.Scene.stackManager.Draw(2));
            }
          public override void PlayUpdate()
            {
                while (own.FirstPlayableCard != null)
                {
                    var card = own.FirstPlayableCard;
                    if (card is Attack)
                    {
                        own.Play(card, GameManager.Instance.Scene.players[0].id == own.id ? GameManager.Instance.Scene.players[1] : GameManager.Instance.Scene.players[0]);
                    }
                    else { own.Play(card); }
                }
            }
          public override  void DiscardUpdate()
            {
                int maxCards = own.Hp > 0 ? own.Hp : 0;
                int discardNum = own.handCardsArea.Count - maxCards;
                own.Discard(discardNum);
            }
          public override void EndUpdate()
            {

            }
        }
    class LitteDemoAI : BaiBanAI
    {
        public LitteDemoAI(Player own) : base(own)
        {
        }
    }
    class YoumuAI : BaiBanAI
    {
        public YoumuAI(Player own) : base(own)
        {
        }
    }
}
